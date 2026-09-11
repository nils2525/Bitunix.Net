using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
using Microsoft.Extensions.Logging;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Owns one explicit batch of native channel memberships.</summary>
internal sealed class BitunixSubscription<T> : Subscription
{
    #region Fields
    private readonly string _channel;
    private readonly string[] _symbols;
    private readonly Action<DateTime, string?, BitunixSocketEvent<T>> _handler;
    #endregion

    #region Constructors
    /// <summary>Creates a batch subscription.</summary>
    internal BitunixSubscription(ILogger logger, string channel, string[] symbols, Action<DateTime, string?, BitunixSocketEvent<T>> handler) : base(logger, false)
    {
        _channel = channel;
        _symbols = symbols;
        _handler = handler;
        IndividualSubscriptionCount = symbols.Length;
        // Aggregate tickers may omit the envelope symbol. Route once per batch and filter each item downstream.
        MessageRouter = channel == "tickers"
            ? MessageRouter.Create(MessageRoute.CreateForEvent<BitunixSocketEvent<T>>(channel, HandleMessage))
            : MessageRouter.Create(symbols.Select(s => MessageRoute.CreateForEvent<BitunixSocketEvent<T>>(channel, s, HandleMessage)).ToArray());
    }
    #endregion

    #region Methods
    private BitunixQuery CreateQuery(string operation) => new(new BitunixSocketRequest
    {
        Operation = operation,
        Arguments = _symbols.Select(s => new BitunixSocketArgument { Channel = _channel, Symbol = s }).ToArray()
    });
    private CallResult HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BitunixSocketEvent<T> message)
    {
        _handler(receiveTime, originalData, message);
        return CallResult.Ok();
    }
    /// <inheritdoc />
    protected override Query? GetSubQuery(SocketConnection connection) => CreateQuery("subscribe");
    /// <inheritdoc />
    protected override Query? GetUnsubQuery(SocketConnection connection) => CreateQuery("unsubscribe");
    #endregion
}
