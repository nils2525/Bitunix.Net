using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
using Microsoft.Extensions.Logging;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Owns an explicit batch of lowercase public website channels.</summary>
internal sealed class BitunixSpotSubscription : Subscription
{
    #region Fields
    private readonly string[] _channels;
    private readonly Dictionary<string, string> _symbolsByChannel;
    private readonly Action<DateTime, string?, string, string, BitunixSpotSocketItem> _handler;
    #endregion

    #region Properties
    /// <inheritdoc />
    public override string[] SubscriptionIdentifiers { get; }
    #endregion

    #region Constructors
    /// <summary>Creates one homogeneous channel batch, retaining native symbol identities for delivery.</summary>
    internal BitunixSpotSubscription(ILogger logger, string prefix, string[] symbols, Action<DateTime, string?, string, string, BitunixSpotSocketItem> handler) : base(logger, false)
    {
        _channels = symbols.Select(symbol => prefix + symbol).ToArray();
        _symbolsByChannel = symbols.ToDictionary(symbol => prefix + symbol, symbol => symbol, StringComparer.Ordinal);
        _handler = handler;
        IndividualSubscriptionCount = _channels.Length;
        // Frames batch heterogeneous channels; CEN deserializes the common envelope once and each owner selects its channels.
        // The website envelope has no single topic filter, so the routes alone would give every batch the same identity.
        // CEN would then treat a second batch as already subscribed and never send its channels, while adding a
        // batch-specific route makes all batches partially overlap and forces each onto its own connection. Identifying
        // the subscription by its channels lets disjoint batches share a connection, serves an identical batch once and
        // keeps batches sharing a channel apart, so closing one never unsubscribes the other.
        SubscriptionIdentifiers = _channels;
        MessageRouter = MessageRouter.Create(
            EventRoute<BitunixSpotSocketEvent>.CreateWithoutTopicFilter("sub", HandleMessage),
            EventRoute<BitunixSpotSocketEvent>.CreateWithoutTopicFilter("push", HandleMessage));
    }
    #endregion

    #region Methods
    private CallResult HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, BitunixSpotSocketEvent message)
    {
        foreach (var item in message.Items)
            if (_symbolsByChannel.TryGetValue(item.Channel, out var symbol))
                _handler(receiveTime, originalData, message.Event, symbol, item);
        return CallResult.Ok();
    }
    /// <inheritdoc />
    protected override Query? GetSubQuery(SocketConnection connection) => new BitunixSpotQuery(new() { Event = "sub", Channel = string.Join(",", _channels) });
    /// <inheritdoc />
    protected override Query? GetUnsubQuery(SocketConnection connection) => new BitunixSpotQuery(new() { Event = "unsub", Channel = string.Join(",", _channels) });
    #endregion
}
