using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.RateLimiting.Filters;
using CryptoExchange.Net.RateLimiting.Interfaces;
namespace Bitunix.Net;
/// <summary>Bitunix API rate limits.</summary>
public sealed class BitunixRateLimiters
{
    #region Properties
    /// <summary>Futures REST endpoint budgets: 10 requests per second per IP.</summary>
    internal IRateLimitGate Rest { get; }
    /// <summary>Private futures endpoints: 10 requests per second per UID; shared local endpoint budgets conservatively cover multiple keys.</summary>
    internal IRateLimitGate PrivateRest { get; }
    /// <summary>Order cancellation and flash close: 5 requests per second per UID.</summary>
    internal IRateLimitGate PrivateTrading { get; }
    /// <summary>Conservative spot pacing of one request per second. Read budgets are undocumented; transfers allow 10 per second per IP.</summary>
    internal IRateLimitGate SpotRest { get; }
    /// <summary>Conservative website pacing of one operation per second per connection; venue budgets are undocumented.</summary>
    internal IRateLimitGate SpotSocket { get; }
    /// <summary>WebSocket operations, including heartbeat: 5 messages per second per connection.</summary>
    internal IRateLimitGate Socket { get; }
    #endregion

    #region Events
    /// <summary>Raised when a rate limit is reached.</summary>
    public event Action<RateLimitEvent>? RateLimitTriggered;
    /// <summary>Raised when a budget changes.</summary>
    public event Action<RateLimitUpdateEvent>? RateLimitUpdated;
    #endregion

    #region Constructors
    /// <summary>Creates venue rate-limit gates.</summary>
    internal BitunixRateLimiters()
    {
        Rest = new RateLimitGate("Bitunix REST").AddGuard(new RateLimitGuard(RateLimitGuard.PerEndpoint, new LimitItemTypeFilter(RateLimitItemType.Request), 10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
        PrivateRest = new RateLimitGate("Bitunix private REST").AddGuard(new RateLimitGuard(RateLimitGuard.PerEndpoint, new LimitItemTypeFilter(RateLimitItemType.Request), 10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
        PrivateTrading = new RateLimitGate("Bitunix private trading").AddGuard(new RateLimitGuard(RateLimitGuard.PerEndpoint, new LimitItemTypeFilter(RateLimitItemType.Request), 5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
        SpotRest = new RateLimitGate("Bitunix Spot REST").AddGuard(new RateLimitGuard(RateLimitGuard.PerEndpoint, new LimitItemTypeFilter(RateLimitItemType.Request), 1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
        Socket = new RateLimitGate("Bitunix WebSocket").AddGuard(new RateLimitGuard(RateLimitGuard.PerConnection, new LimitItemTypeFilter(RateLimitItemType.Request), 5, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
        SpotSocket = new RateLimitGate("Bitunix Spot WebSocket").AddGuard(new RateLimitGuard(RateLimitGuard.PerConnection, new LimitItemTypeFilter(RateLimitItemType.Request), 1, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
        Rest.RateLimitTriggered += e => RateLimitTriggered?.Invoke(e);
        PrivateRest.RateLimitTriggered += e => RateLimitTriggered?.Invoke(e);
        PrivateTrading.RateLimitTriggered += e => RateLimitTriggered?.Invoke(e);
        SpotRest.RateLimitTriggered += e => RateLimitTriggered?.Invoke(e);
        Socket.RateLimitTriggered += e => RateLimitTriggered?.Invoke(e);
        SpotSocket.RateLimitTriggered += e => RateLimitTriggered?.Invoke(e);
        Rest.RateLimitUpdated += e => RateLimitUpdated?.Invoke(e);
        PrivateRest.RateLimitUpdated += e => RateLimitUpdated?.Invoke(e);
        PrivateTrading.RateLimitUpdated += e => RateLimitUpdated?.Invoke(e);
        SpotRest.RateLimitUpdated += e => RateLimitUpdated?.Invoke(e);
        Socket.RateLimitUpdated += e => RateLimitUpdated?.Invoke(e);
        SpotSocket.RateLimitUpdated += e => RateLimitUpdated?.Invoke(e);
    }
    #endregion
}
