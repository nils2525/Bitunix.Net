using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
namespace Bitunix.Net.Interfaces.Clients.FuturesApi;
/// <summary>Bitunix public futures streams.</summary>
public interface IBitunixSocketClientFuturesApi : ISocketApiClient<BitunixCredentials>
{
    /// <summary>Subscribes to explicit ticker symbols. <see href="https://www.bitunix.com/api-docs/futures/websocket/public/Tickers%20Channel.html" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixTickerUpdate>> handler, CancellationToken ct = default);
    /// <summary>Subscribes to mark/index prices and the last funding settlement. <see href="https://www.bitunix.com/api-docs/futures/websocket/public/MarketPrice%20Channel.html" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToPriceUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixPriceUpdate>> handler, CancellationToken ct = default);
    /// <summary>Subscribes to public trades. <see href="https://www.bitunix.com/api-docs/futures/websocket/public/Trade%20Channel.html" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixTrade[]>> handler, CancellationToken ct = default);
}
