using Bitunix.Net.Interfaces.Clients.FuturesApi;
using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net.Clients.FuturesApi;
/// <inheritdoc />
internal sealed class BitunixRestClientFuturesApiTrading(BitunixRestClientFuturesApi client) : IBitunixRestClientFuturesApiTrading
{
    #region Statics
    private static readonly RequestDefinitionCache Definitions = new();
    #endregion

    #region Methods
    private Task<HttpResult<T>> SendAsync<T>(HttpMethod method, string path, Parameters parameters, CancellationToken ct, bool lowRate = false)
    {
        var gate = lowRate ? BitunixExchange.RateLimiter.PrivateTrading : BitunixExchange.RateLimiter.PrivateRest;
        var definition = Definitions.GetOrCreate(method, client.BaseAddress, "/api/v1/futures/" + path, gate, 1, true);
        return client.SendAsync<T>(definition, parameters, ct);
    }
    private static Parameters PageParameters(string? symbol, DateTime? startTime, DateTime? endTime, long? skip, int? limit)
    {
        if (skip < 0)
            throw new ArgumentOutOfRangeException(nameof(skip));
        if (limit is < 1 or > 100)
            throw new ArgumentOutOfRangeException(nameof(limit));
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        parameters.Add("symbol", symbol);
        parameters.Add("startTime", startTime);
        parameters.Add("endTime", endTime);
        parameters.Add("skip", skip);
        parameters.Add("limit", limit);
        return parameters;
    }
    private static void ValidateOrderIdentifier(string? orderId, string? clientOrderId)
    {
        if (string.IsNullOrWhiteSpace(orderId) && string.IsNullOrWhiteSpace(clientOrderId))
            throw new ArgumentException("An exchange order identifier or client order identifier is required.");
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixOrderId>> PlaceOrderAsync(string symbol, string side, string orderType, decimal quantity, decimal? price = null, string? tradeSide = null, string? positionId = null, string? timeInForce = null, string? clientOrderId = null, bool? reduceOnly = null, CancellationToken ct = default)
    {
        if (side is not ("BUY" or "SELL"))
            throw new ArgumentOutOfRangeException(nameof(side));
        if (orderType is not ("LIMIT" or "MARKET"))
            throw new ArgumentOutOfRangeException(nameof(orderType));
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));
        if (orderType == "LIMIT" && (price == null || price <= 0))
            throw new ArgumentOutOfRangeException(nameof(price));
        if (tradeSide is not (null or "OPEN" or "CLOSE"))
            throw new ArgumentOutOfRangeException(nameof(tradeSide));
        if (tradeSide == "CLOSE" && string.IsNullOrWhiteSpace(positionId))
            throw new ArgumentException("Closing a hedge position requires its identifier.", nameof(positionId));
        if (timeInForce is not (null or "IOC" or "FOK" or "GTC" or "POST_ONLY"))
            throw new ArgumentOutOfRangeException(nameof(timeInForce));
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        parameters.Add("symbol", symbol);
        parameters.Add("side", side);
        parameters.Add("orderType", orderType);
        parameters.Add("qty", quantity, DecimalSerialization.String);
        parameters.Add("price", price, DecimalSerialization.String);
        parameters.Add("tradeSide", tradeSide);
        parameters.Add("positionId", positionId);
        parameters.Add("effect", timeInForce);
        parameters.Add("clientId", clientOrderId);
        parameters.Add("reduceOnly", reduceOnly);
        return SendAsync<BitunixOrderId>(HttpMethod.Post, "trade/place_order", parameters, ct);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixOrder>> GetOrderAsync(string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
    {
        ValidateOrderIdentifier(orderId, clientOrderId);
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        parameters.Add("orderId", orderId);
        parameters.Add("clientId", clientOrderId);
        return SendAsync<BitunixOrder>(HttpMethod.Get, "trade/get_order_detail", parameters, ct);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixOrderPage>> GetOpenOrdersAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, string? status = null, DateTime? startTime = null, DateTime? endTime = null, long? skip = null, int? limit = null, CancellationToken ct = default)
    {
        var parameters = PageParameters(symbol, startTime, endTime, skip, limit);
        parameters.Add("orderId", orderId);
        parameters.Add("clientId", clientOrderId);
        parameters.Add("status", status);
        return SendAsync<BitunixOrderPage>(HttpMethod.Get, "trade/get_pending_orders", parameters, ct);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixOrderPage>> GetOrderHistoryAsync(string? symbol = null, string? orderId = null, string? clientOrderId = null, string? status = null, string? orderType = null, DateTime? startTime = null, DateTime? endTime = null, long? skip = null, int? limit = null, bool? queryCanceled = null, CancellationToken ct = default)
    {
        var parameters = PageParameters(symbol, startTime, endTime, skip, limit);
        parameters.Add("orderId", orderId);
        parameters.Add("clientId", clientOrderId);
        parameters.Add("status", status);
        parameters.Add("type", orderType);
        parameters.Add("queryCanceled", queryCanceled, BoolSerialization.String);
        return SendAsync<BitunixOrderPage>(HttpMethod.Get, "trade/get_history_orders", parameters, ct);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixUserTradePage>> GetUserTradesAsync(string? symbol = null, string? orderId = null, string? positionId = null, DateTime? startTime = null, DateTime? endTime = null, long? skip = null, int? limit = null, CancellationToken ct = default)
    {
        var parameters = PageParameters(symbol, startTime, endTime, skip, limit);
        parameters.Add("orderId", orderId);
        parameters.Add("positionId", positionId);
        return SendAsync<BitunixUserTradePage>(HttpMethod.Get, "trade/get_history_trades", parameters, ct);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixPosition[]>> GetPositionsAsync(string? symbol = null, string? positionId = null, CancellationToken ct = default)
    {
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        parameters.Add("symbol", symbol);
        parameters.Add("positionId", positionId);
        parameters.Add("includeSubAccounts", false, BoolSerialization.String);
        return SendAsync<BitunixPosition[]>(HttpMethod.Get, "position/get_pending_positions", parameters, ct);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixPositionHistoryPage>> GetPositionHistoryAsync(string? symbol = null, string? positionId = null, DateTime? startTime = null, DateTime? endTime = null, long? skip = null, int? limit = null, CancellationToken ct = default)
    {
        var parameters = PageParameters(symbol, startTime, endTime, skip, limit);
        parameters.Add("positionId", positionId);
        return SendAsync<BitunixPositionHistoryPage>(HttpMethod.Get, "position/get_history_positions", parameters, ct);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixCancelOrdersResult>> CancelOrderAsync(string symbol, string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
    {
        ValidateOrderIdentifier(orderId, clientOrderId);
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        parameters.Add("symbol", symbol);
        parameters.Add("orderList", new[] { new BitunixCancelOrderRequest { OrderId = orderId, ClientOrderId = clientOrderId } });
        return SendAsync<BitunixCancelOrdersResult>(HttpMethod.Post, "trade/cancel_orders", parameters, ct, true);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixPositionId>> ClosePositionAsync(string positionId, CancellationToken ct = default)
    {
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        parameters.Add("positionId", positionId);
        return SendAsync<BitunixPositionId>(HttpMethod.Post, "trade/flash_close_position", parameters, ct, true);
    }
    #endregion
}

