using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Futures position event.</summary>
public class BitunixPositionUpdate
{
    /// <summary>[<c>event</c>] OPEN, UPDATE or CLOSE.</summary>
    [JsonPropertyName("event")]
    public string Event { get; set; } = "";
    /// <summary>[<c>positionId</c>] Position identifier.</summary>
    [JsonPropertyName("positionId")]
    public string PositionId { get; set; } = "";
    /// <summary>[<c>marginMode</c>] ISOLATION or CROSS.</summary>
    [JsonPropertyName("marginMode")]
    public string MarginMode { get; set; } = "";
    /// <summary>[<c>positionMode</c>] ONE_WAY or HEDGE.</summary>
    [JsonPropertyName("positionMode")]
    public string PositionMode { get; set; } = "";
    /// <summary>[<c>side</c>] LONG or SHORT.</summary>
    [JsonPropertyName("side")]
    public string Side { get; set; } = "";
    /// <summary>[<c>leverage</c>] Position leverage.</summary>
    [JsonPropertyName("leverage")]
    public decimal Leverage { get; set; }
    /// <summary>[<c>margin</c>] Position margin.</summary>
    [JsonPropertyName("margin")]
    public decimal Margin { get; set; }
    /// <summary>[<c>ctime</c>] Creation time.</summary>
    [JsonPropertyName("ctime")]
    public DateTime CreateTime { get; set; }
    /// <summary>[<c>qty</c>] Open position quantity in base asset.</summary>
    [JsonPropertyName("qty")]
    public decimal Quantity { get; set; }
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>realizedPNL</c>] Realized profit excluding funding and trading fees.</summary>
    [JsonPropertyName("realizedPNL")]
    public decimal RealizedPnl { get; set; }
    /// <summary>[<c>unrealizedPNL</c>] Unrealized profit.</summary>
    [JsonPropertyName("unrealizedPNL")]
    public decimal UnrealizedPnl { get; set; }
    /// <summary>[<c>funding</c>] Cumulative funding fees.</summary>
    [JsonPropertyName("funding")]
    public decimal Funding { get; set; }
    /// <summary>[<c>fee</c>] Cumulative deducted trading fees.</summary>
    [JsonPropertyName("fee")]
    public decimal Fee { get; set; }
}
