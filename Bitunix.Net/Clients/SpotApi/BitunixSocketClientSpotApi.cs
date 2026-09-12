using System.Net.WebSockets;
using Bitunix.Net.Clients.MessageHandlers;
using Bitunix.Net.Interfaces.Clients.SpotApi;
using Bitunix.Net.Objects.Models;
using Bitunix.Net.Objects.Options;
using Bitunix.Net.Objects.Sockets;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;
namespace Bitunix.Net.Clients.SpotApi;
/// <summary>Plain JSON implementation of the first-party public spot website feed.</summary>
internal sealed class BitunixSocketClientSpotApi : SocketApiClient<BitunixEnvironment, BitunixAuthenticationProvider, BitunixCredentials>, IBitunixSocketClientSpotApi
{
    #region Constructors
    /// <summary>Creates the spot socket API with independent website heartbeat and pacing.</summary>
    internal BitunixSocketClientSpotApi(ILoggerFactory? loggerFactory, BitunixSocketOptions options) : base(loggerFactory, BitunixExchange.Metadata.Id, options.Environment.SpotSocketClientAddress, options, options.SpotOptions)
    {
        RateLimiter = BitunixExchange.RateLimiter.SpotSocket;
        // Local conservative cap, not a documented venue limit; keep at most two maximum-size batches per connection.
        MaxIndividualSubscriptionsPerConnection = BitunixExchange.SpotSymbolsPerSubscription * 2;
        AddSystemSubscription(new BitunixSpotSystemSubscription(_logger));
        RegisterPeriodicQuery("Ping", TimeSpan.FromSeconds(3), _ => new BitunixSpotPingQuery(), (connection, result) =>
        {
            if (result.Error?.ErrorType == ErrorType.Timeout) _ = connection.TriggerReconnectAsync();
        });
    }
    #endregion

    #region Methods
    private static string[] ValidateSymbols(IEnumerable<string> symbols)
    {
        ArgumentNullException.ThrowIfNull(symbols);
        var result = new HashSet<string>(StringComparer.Ordinal);
        foreach (var symbol in symbols)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(symbol);
            if (symbol.Any(character => !char.IsAsciiLetterOrDigit(character))) throw new ArgumentException("Bitunix spot subscriptions require explicit alphanumeric symbols.", nameof(symbols));
            // Uppercase is deceptively accepted for snapshots, but receives no subsequent live pushes.
            result.Add(symbol.ToLowerInvariant());
        }
        if (result.Count is < 1 || result.Count > BitunixExchange.SpotSymbolsPerSubscription) throw new ArgumentException($"A spot batch requires 1 to {BitunixExchange.SpotSymbolsPerSubscription} symbols.", nameof(symbols));
        return result.ToArray();
    }
    private DataEvent<T> CreateEvent<T>(T data, string symbol, string channel, string eventType, DateTime timestamp, DateTime receiveTime, string? originalData)
    {
        // Historical snapshots must not poison the shared clock offset and make stale quotes look fresh.
        if ((timestamp - receiveTime).Duration() <= TimeSpan.FromSeconds(30)) UpdateTimeOffset(timestamp);
        return new DataEvent<T>(BitunixExchange.Metadata.Id, data, receiveTime, originalData).WithSymbol(symbol).WithStreamId(channel)
            .WithUpdateType(eventType == "sub" ? SocketUpdateType.Snapshot : SocketUpdateType.Update).WithDataTimestamp(timestamp, GetTimeOffset());
    }
    /// <inheritdoc />
    protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(BitunixExchange.SerializerContext);
    /// <inheritdoc />
    protected override BitunixAuthenticationProvider CreateAuthenticationProvider(BitunixCredentials credentials) => new(credentials);
    /// <inheritdoc />
    public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType) => new BitunixSpotSocketMessageHandler();
    /// <inheritdoc />
    public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null) => BitunixExchange.FormatSymbol(baseAsset, quoteAsset, TradingMode.Spot);
    /// <inheritdoc />
    public Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixSpotTicker>> handler, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(handler);
        var subscription = new BitunixSpotSubscription(_logger, "spot_market_", ValidateSymbols(symbols), (received, original, eventType, symbol, item) =>
        {
            if (item.Market is { } market) handler(CreateEvent(market, symbol, item.Channel, eventType, market.Timestamp, received, original));
        });
        return SubscribeAsync(BaseAddress, subscription, ct);
    }
    /// <inheritdoc />
    public Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixSpotTradeUpdate>> handler, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(handler);
        var subscription = new BitunixSpotSubscription(_logger, "spot_deals_", ValidateSymbols(symbols), (received, original, eventType, symbol, item) =>
        {
            if (item.Deals is { } trades) handler(CreateEvent(trades, symbol, item.Channel, eventType, trades.Timestamp, received, original));
        });
        return SubscribeAsync(BaseAddress, subscription, ct);
    }
    /// <inheritdoc />
    public Task<WebSocketResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixSpotBestPrice>> handler, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(handler);
        var subscription = new BitunixSpotSubscription(_logger, "spot_best_price_", ValidateSymbols(symbols), (received, original, eventType, symbol, item) =>
        {
            if (item.BestPrice is { } book) handler(CreateEvent(book, symbol, item.Channel, eventType, book.Timestamp, received, original));
        });
        return SubscribeAsync(BaseAddress, subscription, ct);
    }
    #endregion
}
