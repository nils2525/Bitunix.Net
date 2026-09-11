using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Bitunix channel envelope.</summary>
internal class BitunixSocketEvent
{
    /// <summary>[<c>ch</c>] Channel.</summary>
    [JsonPropertyName("ch")]
    public string Channel { get; set; } = "";
    /// <summary>[<c>symbol</c>] Native symbol, omitted for aggregate envelopes.</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }
    /// <summary>[<c>ts</c>] Server time in milliseconds.</summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
}
