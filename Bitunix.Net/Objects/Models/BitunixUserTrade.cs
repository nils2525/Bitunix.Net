using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Executed futures fill.</summary>
public class BitunixUserTrade
{
    /// <summary>[<c>tradeId</c>] Exchange fill identifier.</summary>
    [JsonPropertyName("tradeId")]
    public string TradeId { get; set; } = "";
    /// <summary>[<c>orderId</c>] Exchange order identifier.</summary>
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; } = "";
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>marginCoin</c>] Margin asset; the live API can return null.</summary>
    [JsonPropertyName("marginCoin")]
    public string? MarginAsset { get; set; }
    /// <summary>[<c>status</c>] Native order status, when supplied by the trade response.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
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
    /// <summary>[<c>roleType</c>] MAKER or TAKER liquidity role.</summary>
    [JsonPropertyName("roleType")]
    public string Role { get; set; } = "";
}
