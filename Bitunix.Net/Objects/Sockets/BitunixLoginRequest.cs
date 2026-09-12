using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Futures socket authentication request.</summary>
internal sealed class BitunixLoginRequest
{
    /// <summary>[<c>op</c>] Login operation.</summary>
    [JsonPropertyName("op")]
    public string Operation => "login";
    /// <summary>[<c>args</c>] Signed authentication arguments.</summary>
    [JsonPropertyName("args")]
    public BitunixLoginArgument[] Arguments { get; set; } = [];
}
