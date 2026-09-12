using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Public website JSON envelope; a frame may contain multiple different market channels.</summary>
internal sealed class BitunixSpotSocketEvent
{
    /// <summary>[<c>event</c>] Subscriptions begin with sub snapshots, followed by push updates.</summary>
    [JsonPropertyName("event")]
    public string Event { get; set; } = "";
    /// <summary>[<c>ts</c>] Envelope timestamp.</summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
    /// <summary>[<c>market_items</c>] Channel deliveries.</summary>
    [JsonPropertyName("market_items")]
    public BitunixSpotSocketItem[] Items { get; set; } = [];
}
