using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Open futures position.</summary>
public class BitunixPosition
{
    /// <summary>[<c>positionId</c>] Exchange position identifier.</summary>
    [JsonPropertyName("positionId")]
    public string PositionId { get; set; } = "";
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>marginCoin</c>] Settlement asset; the live position endpoint can explicitly return null.</summary>
    [JsonPropertyName("marginCoin")]
    public string? MarginAsset { get; set; }
    /// <summary>[<c>side</c>] LONG or SHORT in the documentation; BUY or SELL in live positions.</summary>
    [JsonPropertyName("side")]
    public string Side { get; set; } = "";
    /// <summary>[<c>marginMode</c>] ISOLATION or CROSS.</summary>
    [JsonPropertyName("marginMode")]
    public string MarginMode { get; set; } = "";
    /// <summary>[<c>positionMode</c>] ONE_WAY or HEDGE.</summary>
    [JsonPropertyName("positionMode")]
    public string PositionMode { get; set; } = "";
    /// <summary>[<c>leverage</c>] Leverage multiplier.</summary>
    [JsonPropertyName("leverage")]
    public int Leverage { get; set; }
    /// <summary>[<c>fee</c>] Transaction fees deducted during this position.</summary>
    [JsonPropertyName("fee")]
    public decimal Fee { get; set; }
    /// <summary>[<c>funding</c>] Accumulated funding fees.</summary>
    [JsonPropertyName("funding")]
    public decimal Funding { get; set; }
    /// <summary>[<c>realizedPNL</c>] Realized profit excluding funding and trading fees.</summary>
    [JsonPropertyName("realizedPNL")]
    public decimal RealizedPnl { get; set; }
    /// <summary>[<c>liqPrice</c>] Estimated liquidation price; nonpositive when no liquidation price applies.</summary>
    [JsonPropertyName("liqPrice")]
    public decimal LiquidationPrice { get; set; }
    /// <summary>[<c>ctime</c>] Creation timestamp, UTC.</summary>
    [JsonPropertyName("ctime")]
    public DateTime CreateTime { get; set; }
    /// <summary>[<c>mtime</c>] Latest update timestamp, UTC.</summary>
    [JsonPropertyName("mtime")]
    public DateTime UpdateTime { get; set; }
    /// <summary>[<c>subAccountId</c>] Owning account identifier, when returned.</summary>
    [JsonPropertyName("subAccountId")]
    public long? SubAccountId { get; set; }
    /// <summary>[<c>qty</c>] Position quantity.</summary>
    [JsonPropertyName("qty")]
    public decimal Quantity { get; set; }
    /// <summary>[<c>entryValue</c>] Entry value of the position.</summary>
    [JsonPropertyName("entryValue")]
    public decimal EntryValue { get; set; }
    /// <summary>[<c>margin</c>] Balance locked by this position.</summary>
    [JsonPropertyName("margin")]
    public decimal Margin { get; set; }
    /// <summary>[<c>unrealizedPNL</c>] Unrealized profit.</summary>
    [JsonPropertyName("unrealizedPNL")]
    public decimal UnrealizedPnl { get; set; }
    /// <summary>[<c>marginRate</c>] Margin ratio.</summary>
    [JsonPropertyName("marginRate")]
    public decimal MarginRate { get; set; }
    /// <summary>[<c>avgOpenPrice</c>] Average opening price.</summary>
    [JsonPropertyName("avgOpenPrice")]
    public decimal AverageOpenPrice { get; set; }
}
