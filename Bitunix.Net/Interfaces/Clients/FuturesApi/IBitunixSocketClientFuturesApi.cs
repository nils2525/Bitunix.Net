using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
namespace Bitunix.Net.Interfaces.Clients.FuturesApi;
/// <summary>Bitunix public market and authenticated futures account streams.</summary>
public interface IBitunixSocketClientFuturesApi : ISocketApiClient<BitunixCredentials>
{
    /// <summary>Subscribes to explicit ticker symbols. <see href="https://www.bitunix.com/api-docs/futures/websocket/public/Tickers%20Channel.html" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixTickerUpdate>> handler, CancellationToken ct = default);
    /// <summary>Subscribes to mark/index prices and the last funding settlement. <see href="https://www.bitunix.com/api-docs/futures/websocket/public/MarketPrice%20Channel.html" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToPriceUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixPriceUpdate>> handler, CancellationToken ct = default);
    /// <summary>Subscribes to public trades. <see href="https://www.bitunix.com/api-docs/futures/websocket/public/Trade%20Channel.html" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<BitunixTrade[]>> handler, CancellationToken ct = default);
    /// <summary>Subscribes to complete 1, 5 or 15-level order-book snapshots. <see href="https://www.bitunix.com/api-docs/futures/websocket/public/depth%20channel.html" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(IEnumerable<string> symbols, int depth, Action<DataEvent<BitunixOrderBookUpdate>> handler, CancellationToken ct = default);
    /// <summary>Subscribes to all futures account balance updates. <see href="https://www.bitunix.com/api-docs/futures/websocket/private/Balance%20Channel.html" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<BitunixBalanceUpdate>> handler, CancellationToken ct = default);
    /// <summary>Subscribes to all futures order updates. <see href="https://www.bitunix.com/api-docs/futures/websocket/private/Order%20Channel.html" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<BitunixOrderUpdate>> handler, CancellationToken ct = default);
    /// <summary>Subscribes to all futures position updates. <see href="https://www.bitunix.com/api-docs/futures/websocket/private/Position%20Channel.html" /></summary>
    Task<WebSocketResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(Action<DataEvent<BitunixPositionUpdate>> handler, CancellationToken ct = default);
}
