using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
namespace Bitunix.Net.Interfaces.Clients.SpotApi;
/// <summary>Unauthenticated spot streams used by the Bitunix website; these subscriptions are not in the published spot API reference.</summary>
/// <remarks>
/// Symbols are normalized to lowercase because uppercase channels receive snapshots without subsequent updates.
/// A successful subscription result confirms sending the request: the website has no correlated acknowledgement,
/// and unknown symbols can remain silent. Snapshot and live deliveries are distinguished by UpdateType.
/// The local batch limit is <see cref="BitunixExchange.SpotSymbolsPerSubscription" />, validated by a public live probe;
/// the venue's hard connection and channel limits are undocumented.
/// </remarks>
public interface IBitunixSocketClientSpotApi : ISocketApiClient<BitunixCredentials>
{
    /// <summary>Subscribes to rolling market statistics for explicit symbols. First-party protocol: spot_market_{symbol}. <see href="https://www.bitunix.com/spot-trade/BTCUSDT" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixSpotTicker>> handler, CancellationToken ct = default);
    /// <summary>Subscribes to trade snapshots and live batches. First-party protocol: spot_deals_{symbol}. Account-confirmed execution probes identify native buy/sell as taker side. <see href="https://www.bitunix.com/spot-trade/BTCUSDT" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixSpotTradeUpdate>> handler, CancellationToken ct = default);
    /// <summary>Subscribes to exact best bid/ask prices and base quantities. First-party protocol: spot_best_price_{symbol}. Each update replaces both best quotes; no price aggregation or depth parameter is needed. <see href="https://www.bitunix.com/spot-trade/BTCUSDT" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToBookTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixSpotBestPrice>> handler, CancellationToken ct = default);
}
