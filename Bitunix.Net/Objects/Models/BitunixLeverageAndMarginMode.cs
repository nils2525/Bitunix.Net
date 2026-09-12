using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Symbol leverage and margin configuration.</summary>
public class BitunixLeverageAndMarginMode
{
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>marginCoin</c>] Settlement asset.</summary>
    [JsonPropertyName("marginCoin")]
    public string MarginAsset { get; set; } = "";
    /// <summary>[<c>leverage</c>] Leverage multiplier.</summary>
    [JsonPropertyName("leverage")]
    public int Leverage { get; set; }
    /// <summary>[<c>longLeverage</c>] Long-side leverage returned by the live API, when available.</summary>
    [JsonPropertyName("longLeverage")]
    public int? LongLeverage { get; set; }
    /// <summary>[<c>shortLeverage</c>] Short-side leverage returned by the live API, when available.</summary>
    [JsonPropertyName("shortLeverage")]
    public int? ShortLeverage { get; set; }
    /// <summary>[<c>marginMode</c>] ISOLATION or CROSS.</summary>
    [JsonPropertyName("marginMode")]
    public string MarginMode { get; set; } = "";
}
