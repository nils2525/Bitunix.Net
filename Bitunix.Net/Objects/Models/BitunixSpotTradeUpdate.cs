using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Spot trade snapshot or incremental batch.</summary>
public class BitunixSpotTradeUpdate
{
    /// <summary>[<c>ts</c>] Batch timestamp.</summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>data</c>] Recent history in snapshots, new fills in updates.</summary>
    [JsonPropertyName("data")]
    public BitunixSpotTrade[] Trades { get; set; } = [];
}
