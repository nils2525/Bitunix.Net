using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net.Interfaces.Clients.FuturesApi;
/// <summary>Bitunix futures trading requests.</summary>
public interface IBitunixRestClientFuturesApiTrading
{
    /// <summary>Places a futures order. In hedge mode side identifies the position direction and tradeSide is OPEN or CLOSE. <a href="https://www.bitunix.com/api-docs/futures/trade/place_order.html" /></summary>
    Task<HttpResult<BitunixOrderId>> PlaceOrderAsync(string symbol, string side, string orderType, decimal quantity, decimal? price = null, string? tradeSide = null, string? positionId = null, string? timeInForce = null, string? clientOrderId = null, bool? reduceOnly = null, CancellationToken ct = default);
    /// <summary>Gets an order by exchange or client identifier. <a href="https://www.bitunix.com/api-docs/futures/trade/get_order_detail.html" /></summary>
    Task<HttpResult<BitunixOrder>> GetOrderAsync(string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);
    /// <summary>Gets pending orders in descending creation order with offset pagination (maximum 100 per page). <a href="https://www.bitunix.com/api-docs/futures/trade/get_pending_orders.html" /></summary>
    Task<HttpResult<BitunixOrderPage>> GetOpenOrdersAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, string? status = null, DateTime? startTime = null, DateTime? endTime = null, long? skip = null, int? limit = null, CancellationToken ct = default);
    /// <summary>Gets historical orders with offset pagination. Canceled orders require queryCanceled and have a three-day lookback; other orders have a 90-day lookback. <a href="https://www.bitunix.com/api-docs/futures/trade/get_history_orders.html" /></summary>
    Task<HttpResult<BitunixOrderPage>> GetOrderHistoryAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, string? status = null, string? orderType = null, DateTime? startTime = null, DateTime? endTime = null, long? skip = null, int? limit = null, bool? queryCanceled = null, CancellationToken ct = default);
    /// <summary>Gets account fills in descending creation order with offset pagination (maximum 100 per page). <a href="https://www.bitunix.com/api-docs/futures/trade/get_history_trades.html" /></summary>
    Task<HttpResult<BitunixUserTradePage>> GetUserTradesAsync(string? symbol = null, string? orderId = null, string? positionId = null, DateTime? startTime = null, DateTime? endTime = null, long? skip = null, int? limit = null, CancellationToken ct = default);
    /// <summary>Gets open positions for the current account with sub-account inclusion disabled. <a href="https://www.bitunix.com/api-docs/futures/position/get_pending_positions.html" /></summary>
    Task<HttpResult<BitunixPosition[]>> GetPositionsAsync(string? symbol = null, string? positionId = null, CancellationToken ct = default);
    /// <summary>Gets historical positions for the current account with offset pagination (maximum 100 per page). <a href="https://www.bitunix.com/api-docs/futures/position/get_history_positions.html" /></summary>
    Task<HttpResult<BitunixPositionHistoryPage>> GetPositionHistoryAsync(string? symbol = null, string? positionId = null, DateTime? startTime = null, DateTime? endTime = null, long? skip = null, int? limit = null, CancellationToken ct = default);
    /// <summary>Submits an order cancellation. The result separates accepted and rejected requests; an accepted request is not final cancellation confirmation. <a href="https://www.bitunix.com/api-docs/futures/trade/cancel_orders.html" /></summary>
    Task<HttpResult<BitunixCancelOrdersResult>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default);
    /// <summary>Closes a position by its identifier at market. <a href="https://www.bitunix.com/api-docs/futures/trade/flash_close_position.html" /></summary>
    Task<HttpResult<BitunixPositionId>> ClosePositionAsync(string positionId, CancellationToken ct = default);
}

