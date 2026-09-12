using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Futures order event.</summary>
public class BitunixOrderUpdate
{
    /// <summary>[<c>event</c>] CREATE, UPDATE or CLOSE.</summary>
    [JsonPropertyName("event")]
    public string Event { get; set; } = "";
    /// <summary>[<c>orderId</c>] Order identifier.</summary>
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; } = "";
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>positionType</c>] ISOLATION or CROSS.</summary>
    [JsonPropertyName("positionType")]
    public string MarginMode { get; set; } = "";
    /// <summary>[<c>positionMode</c>] ONE_WAY or HEDGE.</summary>
    [JsonPropertyName("positionMode")]
    public string PositionMode { get; set; } = "";
    /// <summary>[<c>side</c>] BUY or SELL.</summary>
    [JsonPropertyName("side")]
    public string Side { get; set; } = "";
    /// <summary>[<c>effect</c>] IOC, FOK, GTC or POST_ONLY.</summary>
    [JsonPropertyName("effect")]
    public string TimeInForce { get; set; } = "";
    /// <summary>[<c>type</c>] LIMIT or MARKET.</summary>
    [JsonPropertyName("type")]
    public string OrderType { get; set; } = "";
    /// <summary>[<c>qty</c>] Order quantity in base asset.</summary>
    [JsonPropertyName("qty")]
    public decimal Quantity { get; set; }
    /// <summary>[<c>price</c>] Order price, applicable to limit orders.</summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }
    /// <summary>[<c>ctime</c>] Creation time.</summary>
    [JsonPropertyName("ctime")]
    public DateTime CreateTime { get; set; }
    /// <summary>[<c>mtime</c>] Last modification time.</summary>
    [JsonPropertyName("mtime")]
    public DateTime UpdateTime { get; set; }
    /// <summary>[<c>leverage</c>] Position leverage.</summary>
    [JsonPropertyName("leverage")]
    public decimal Leverage { get; set; }
    /// <summary>[<c>orderStatus</c>] INIT, NEW, PART_FILLED, CANCELED, FILLED or PART_FILLED_CANCELED.</summary>
    [JsonPropertyName("orderStatus")]
    public string Status { get; set; } = "";
    /// <summary>[<c>fee</c>] Deducted trading fees.</summary>
    [JsonPropertyName("fee")]
    public decimal Fee { get; set; }
    /// <summary>[<c>averagePrice</c>] Average execution price.</summary>
    [JsonPropertyName("averagePrice")]
    public decimal AveragePrice { get; set; }
    /// <summary>[<c>dealAmount</c>] Cumulative executed amount.</summary>
    [JsonPropertyName("dealAmount")]
    public decimal FilledQuantity { get; set; }
    /// <summary>[<c>clientId</c>] Client order identifier.</summary>
    [JsonPropertyName("clientId")]
    public string? ClientOrderId { get; set; }
    /// <summary>[<c>tpStopType</c>] MARK_PRICE or LAST_PRICE.</summary>
    [JsonPropertyName("tpStopType")]
    public string? TakeProfitTriggerType { get; set; }
    /// <summary>[<c>tpPrice</c>] Take profit trigger price.</summary>
    [JsonPropertyName("tpPrice")]
    public decimal? TakeProfitPrice { get; set; }
    /// <summary>[<c>tpOrderType</c>] LIMIT or MARKET.</summary>
    [JsonPropertyName("tpOrderType")]
    public string? TakeProfitOrderType { get; set; }
    /// <summary>[<c>tpOrderPrice</c>] Take profit order price.</summary>
    [JsonPropertyName("tpOrderPrice")]
    public decimal? TakeProfitOrderPrice { get; set; }
    /// <summary>[<c>slStopType</c>] MARK_PRICE or LAST_PRICE.</summary>
    [JsonPropertyName("slStopType")]
    public string? StopLossTriggerType { get; set; }
    /// <summary>[<c>slPrice</c>] Stop loss trigger price.</summary>
    [JsonPropertyName("slPrice")]
    public decimal? StopLossPrice { get; set; }
    /// <summary>[<c>slOrderType</c>] LIMIT or MARKET.</summary>
    [JsonPropertyName("slOrderType")]
    public string? StopLossOrderType { get; set; }
    /// <summary>[<c>slOrderPrice</c>] Stop loss order price.</summary>
    [JsonPropertyName("slOrderPrice")]
    public decimal? StopLossOrderPrice { get; set; }
}
