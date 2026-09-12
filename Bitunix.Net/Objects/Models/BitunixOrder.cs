using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Futures order details.</summary>
public class BitunixOrder
{
    /// <summary>[<c>orderId</c>] Exchange order identifier.</summary>
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; } = "";
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>marginCoin</c>] Settlement asset; the live order endpoint can explicitly return null.</summary>
    [JsonPropertyName("marginCoin")]
    public string? MarginAsset { get; set; }
    /// <summary>[<c>qty</c>] Quantity in base asset units.</summary>
    [JsonPropertyName("qty")]
    public decimal Quantity { get; set; }
    /// <summary>[<c>positionMode</c>] ONE_WAY or HEDGE.</summary>
    [JsonPropertyName("positionMode")]
    public string PositionMode { get; set; } = "";
    /// <summary>[<c>marginMode</c>] ISOLATION or CROSS.</summary>
    [JsonPropertyName("marginMode")]
    public string MarginMode { get; set; } = "";
    /// <summary>[<c>leverage</c>] Leverage multiplier.</summary>
    [JsonPropertyName("leverage")]
    public int Leverage { get; set; }
    /// <summary>[<c>price</c>] Order price; applicable to limit orders.</summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }
    /// <summary>[<c>avgPrice</c>] Average execution price; the live unfilled order response explicitly returns null.</summary>
    [JsonPropertyName("avgPrice")]
    public decimal? AveragePrice { get; set; }
    /// <summary>[<c>side</c>] BUY or SELL.</summary>
    [JsonPropertyName("side")]
    public string Side { get; set; } = "";
    /// <summary>[<c>orderType</c>] LIMIT or MARKET as documented in the field table.</summary>
    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }
    /// <summary>[<c>type</c>] LIMIT or MARKET under the field used by the documented example.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    /// <summary>[<c>effect</c>] IOC, FOK, GTC, or POST_ONLY for limit orders.</summary>
    [JsonPropertyName("effect")]
    public string? TimeInForce { get; set; }
    /// <summary>[<c>clientId</c>] Client-provided order identifier.</summary>
    [JsonPropertyName("clientId")]
    public string? ClientOrderId { get; set; }
    /// <summary>[<c>reduceOnly</c>] Whether the order only reduces the position.</summary>
    [JsonPropertyName("reduceOnly")]
    public bool ReduceOnly { get; set; }
    /// <summary>[<c>fee</c>] Charged transaction fee.</summary>
    [JsonPropertyName("fee")]
    public decimal Fee { get; set; }
    /// <summary>[<c>realizedPNL</c>] Realized profit.</summary>
    [JsonPropertyName("realizedPNL")]
    public decimal RealizedPnl { get; set; }
    /// <summary>[<c>source</c>] Order source, shown in the documented response example.</summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }
    /// <summary>[<c>ctime</c>] Creation timestamp, UTC.</summary>
    [JsonPropertyName("ctime")]
    public DateTime CreateTime { get; set; }
    /// <summary>[<c>tradeQty</c>] Filled quantity in base asset units.</summary>
    [JsonPropertyName("tradeQty")]
    public decimal FilledQuantity { get; set; }
    /// <summary>[<c>status</c>] Native order status.</summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = "";
    /// <summary>[<c>tpPrice</c>] Take profit trigger price.</summary>
    [JsonPropertyName("tpPrice")]
    public decimal? TakeProfitPrice { get; set; }
    /// <summary>[<c>tpStopType</c>] Take profit trigger reference.</summary>
    [JsonPropertyName("tpStopType")]
    public string? TakeProfitTriggerType { get; set; }
    /// <summary>[<c>tpOrderType</c>] Take profit execution order type.</summary>
    [JsonPropertyName("tpOrderType")]
    public string? TakeProfitOrderType { get; set; }
    /// <summary>[<c>tpOrderPrice</c>] Take profit limit price.</summary>
    [JsonPropertyName("tpOrderPrice")]
    public decimal? TakeProfitOrderPrice { get; set; }
    /// <summary>[<c>slPrice</c>] Stop loss trigger price.</summary>
    [JsonPropertyName("slPrice")]
    public decimal? StopLossPrice { get; set; }
    /// <summary>[<c>slStopType</c>] Stop loss trigger reference.</summary>
    [JsonPropertyName("slStopType")]
    public string? StopLossTriggerType { get; set; }
    /// <summary>[<c>slOrderType</c>] Stop loss execution order type.</summary>
    [JsonPropertyName("slOrderType")]
    public string? StopLossOrderType { get; set; }
    /// <summary>[<c>slOrderPrice</c>] Stop loss limit price.</summary>
    [JsonPropertyName("slOrderPrice")]
    public decimal? StopLossOrderPrice { get; set; }
    /// <summary>[<c>mtime</c>] Latest update timestamp, UTC.</summary>
    [JsonPropertyName("mtime")]
    public DateTime UpdateTime { get; set; }
    /// <summary>[<c>subAccountId</c>] Owning account identifier, when returned by order history.</summary>
    [JsonPropertyName("subAccountId")]
    public long? SubAccountId { get; set; }
}
