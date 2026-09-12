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

    #region Constructors
    /// <summary>Creates one homogeneous channel batch, retaining native symbol identities for delivery.</summary>
    internal BitunixSpotSubscription(ILogger logger, string prefix, string[] symbols, Action<DateTime, string?, string, string, BitunixSpotSocketItem> handler) : base(logger, false)
    {
        _channels = symbols.Select(symbol => prefix + symbol).ToArray();
        _symbolsByChannel = symbols.ToDictionary(symbol => prefix + symbol, symbol => symbol, StringComparer.Ordinal);
        _handler = handler;
        IndividualSubscriptionCount = _channels.Length;
        // Frames batch heterogeneous channels; CEN deserializes the common envelope once and each owner selects its channels.
        // CEN also uses the complete route set as native subscription identity when deciding whether to unsubscribe.
        // The extra filtered route identifies this exact batch; the website envelope has no single topic filter,
        // so only the two unfiltered routes deliver messages. Distinct batches must never suppress each other's unsub.
        MessageRouter = MessageRouter.Create(
            EventRoute<BitunixSpotSocketEvent>.CreateWithoutTopicFilter("sub", HandleMessage),
            EventRoute<BitunixSpotSocketEvent>.CreateWithoutTopicFilter("push", HandleMessage),
            EventRoute<BitunixSpotSocketEvent>.CreateWithTopicFilter("push", string.Join(",", _channels.OrderBy(x => x, StringComparer.Ordinal)), HandleMessage));
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
