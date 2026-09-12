using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Public website subscription or heartbeat request.</summary>
internal sealed class BitunixSpotSocketRequest
{
    /// <summary>[<c>event</c>] sub, unsub, or ping.</summary>
    [JsonPropertyName("event")]
    public string Event { get; set; } = "";
    /// <summary>[<c>channel</c>] Comma-separated lowercase channels.</summary>
    [JsonPropertyName("channel"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Channel { get; set; }
    /// <summary>[<c>ping</c>] Current Unix seconds for heartbeat requests.</summary>
    [JsonPropertyName("ping"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? Ping { get; set; }
}
