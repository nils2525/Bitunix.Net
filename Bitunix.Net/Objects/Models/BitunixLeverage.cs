using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Changed symbol leverage.</summary>
public class BitunixLeverage
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
}

