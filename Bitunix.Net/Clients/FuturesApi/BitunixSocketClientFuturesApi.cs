using System.Net.WebSockets;
using Bitunix.Net.Clients.MessageHandlers;
using Bitunix.Net.Interfaces.Clients.FuturesApi;
using Bitunix.Net.Objects.Models;
using Bitunix.Net.Objects.Options;
using Bitunix.Net.Objects.Sockets;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters.MessageParsing;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;
namespace Bitunix.Net.Clients.FuturesApi;
/// <inheritdoc />
internal sealed class BitunixSocketClientFuturesApi : SocketApiClient<BitunixEnvironment, BitunixAuthenticationProvider, BitunixCredentials>, IBitunixSocketClientFuturesApi
{
    #region Constructors
    /// <summary>Creates the public and authenticated futures socket API.</summary>
    internal BitunixSocketClientFuturesApi(ILoggerFactory? loggerFactory, BitunixSocketOptions options)
        : base(loggerFactory, BitunixExchange.Metadata.Id, options.Environment.SocketClientAddress, options, options.FuturesOptions)
    {
        RateLimiter = BitunixExchange.RateLimiter.Socket;
        MaxIndividualSubscriptionsPerConnection = 300;
        AddSystemSubscription(new BitunixSystemSubscription(_logger));
        // The docs specify ping messages but no idle timeout. Keep a conservative 10-second heartbeat.
        RegisterPeriodicQuery("Ping", TimeSpan.FromSeconds(10), _ => new BitunixPingQuery(), (connection, result) =>
        {
            if (result.Error?.ErrorType == ErrorType.Timeout)
                _ = connection.TriggerReconnectAsync();
        });
    }
    #endregion

    #region Methods
    private static string[] ValidateSymbols(IEnumerable<string> symbols)
    {
        var result = symbols.Distinct(StringComparer.Ordinal).ToArray();
        if (result.Length == 0 || result.Length > 300 || result.Any(string.IsNullOrWhiteSpace))
            throw new ArgumentException("A Bitunix subscription requires 1 to 300 explicit native symbols.", nameof(symbols));
        return result;
    }
    private DataEvent<T> CreateEvent<T>(T data, string? symbol, string channel, DateTime timestamp, DateTime receiveTime, string? originalData, SocketUpdateType updateType = SocketUpdateType.Update)
    {
        UpdateTimeOffset(timestamp);
        return new DataEvent<T>(BitunixExchange.Metadata.Id, data, receiveTime, originalData)
            .WithSymbol(symbol).WithStreamId(channel).WithUpdateType(updateType).WithDataTimestamp(timestamp, GetTimeOffset());
    }
    private Task<WebSocketResult<UpdateSubscription>> SubscribePrivateAsync<T>(string channel, Action<DataEvent<T>> handler, Func<T, string?> symbolSelector, CancellationToken ct)
    {
        var subscription = new BitunixSubscription<T>(_logger, channel, [],
            (received, original, message) => handler(CreateEvent(message.Data, symbolSelector(message.Data), message.Channel, message.Timestamp, received, original)), authenticated: true);
        return SubscribeAsync(((BitunixSocketOptions)ClientOptions).Environment.PrivateSocketClientAddress, subscription, ct);
    }
    /// <inheritdoc />
    protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(BitunixExchange.SerializerContext);
    /// <inheritdoc />
    protected override BitunixAuthenticationProvider CreateAuthenticationProvider(BitunixCredentials credentials) => new(credentials);
    /// <inheritdoc />
    public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType) => new BitunixSocketMessageHandler();
    /// <inheritdoc />
    public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null) => BitunixExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);
    /// <inheritdoc />
    public Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixTickerUpdate>> handler, CancellationToken ct = default)
    {
        var nativeSymbols = ValidateSymbols(symbols);
        var membership = new HashSet<string>(nativeSymbols, StringComparer.Ordinal);
        var subscription = new BitunixSubscription<BitunixTickerUpdate[]>(_logger, "tickers", nativeSymbols, (received, original, message) =>
        {
            foreach (var ticker in message.Data)
                if (membership.Contains(ticker.Symbol))
                    handler(CreateEvent(ticker, ticker.Symbol, message.Channel, message.Timestamp, received, original));
        });
        return SubscribeAsync(BaseAddress, subscription, ct);
    }
    /// <inheritdoc />
    public Task<WebSocketResult<UpdateSubscription>> SubscribeToPriceUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixPriceUpdate>> handler, CancellationToken ct = default)
    {
        var subscription = new BitunixSubscription<BitunixPriceUpdate>(_logger, "price", ValidateSymbols(symbols),
            (received, original, message) => handler(CreateEvent(message.Data, message.Symbol, message.Channel, message.Timestamp, received, original)));
        return SubscribeAsync(BaseAddress, subscription, ct);
    }
    /// <inheritdoc />
    public Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixTrade[]>> handler, CancellationToken ct = default)
    {
        var subscription = new BitunixSubscription<BitunixTrade[]>(_logger, "trade", ValidateSymbols(symbols),
            (received, original, message) => handler(CreateEvent(message.Data, message.Symbol, message.Channel, message.Timestamp, received, original)));
        return SubscribeAsync(BaseAddress, subscription, ct);
    }
    /// <inheritdoc />
    public Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BitunixOrderBookUpdate>> handler, CancellationToken ct = default)
    {
        if (depth is not (1 or 5 or 15))
            throw new ArgumentOutOfRangeException(nameof(depth), "Bitunix snapshot depth must be 1, 5 or 15.");
        var subscription = new BitunixSubscription<BitunixOrderBookUpdate>(_logger, "depth_book" + depth, ValidateSymbols(symbols),
            (received, original, message) => handler(CreateEvent(message.Data, message.Symbol, message.Channel, message.Timestamp, received, original, SocketUpdateType.Snapshot)));
        return SubscribeAsync(BaseAddress, subscription, ct);
    }
    /// <inheritdoc />
    public Task<WebSocketResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<BitunixBalanceUpdate>> handler, CancellationToken ct = default)
        => SubscribePrivateAsync("balance", handler, static _ => null, ct);
    /// <inheritdoc />
    public Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<BitunixOrderUpdate>> handler, CancellationToken ct = default)
        => SubscribePrivateAsync("order", handler, static data => data.Symbol, ct);
    /// <inheritdoc />
    public Task<WebSocketResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<BitunixPositionUpdate>> handler, CancellationToken ct = default)
        => SubscribePrivateAsync("position", handler, static data => data.Symbol, ct);
    #endregion
}
