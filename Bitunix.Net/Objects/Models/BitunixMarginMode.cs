using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Changed symbol margin mode.</summary>
public class BitunixMarginMode
{
    /// <summary>[<c>symbol</c>] Native symbol, when returned.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }
    /// <summary>[<c>marginCoin</c>] Settlement asset, when returned.</summary>
    [JsonPropertyName("marginCoin")]
    public string? MarginAsset { get; set; }
    /// <summary>[<c>marginMode</c>] ISOLATION or CROSS, when returned.</summary>
    [JsonPropertyName("marginMode")]
    public string? MarginMode { get; set; }
    /// <summary>[<c>positionMode</c>] Margin mode under the alternative field shown by the documented response example.</summary>
    [JsonPropertyName("positionMode")]
    public string? PositionMode { get; set; }
}

