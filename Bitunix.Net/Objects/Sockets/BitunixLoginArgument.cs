using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Signed futures socket login arguments.</summary>
internal sealed class BitunixLoginArgument
{
    /// <summary>[<c>apiKey</c>] API key.</summary>
    [JsonPropertyName("apiKey")]
    public string ApiKey { get; set; } = "";
    /// <summary>[<c>timestamp</c>] Unix seconds used by the documented signing implementations.</summary>
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }
    /// <summary>[<c>nonce</c>] Unique random login nonce.</summary>
    [JsonPropertyName("nonce")]
    public string Nonce { get; set; } = "";
    /// <summary>[<c>sign</c>] Double SHA-256 signature.</summary>
    [JsonPropertyName("sign")]
    public string Signature { get; set; } = "";
}
