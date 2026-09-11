using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Native heartbeat request.</summary>
internal class BitunixPing
{
    /// <summary>[<c>op</c>] Heartbeat operation.</summary>
    [JsonPropertyName("op")]
    public string Operation { get; set; } = "ping";
    /// <summary>[<c>ping</c>] Unix seconds.</summary>
    [JsonPropertyName("ping")]
    public long Timestamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}
