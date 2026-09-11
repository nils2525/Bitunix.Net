using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Public subscription operation.</summary>
internal class BitunixSocketRequest
{
    /// <summary>[<c>op</c>] subscribe or unsubscribe.</summary>
    [JsonPropertyName("op")]
    public string Operation { get; set; } = "";
    /// <summary>[<c>args</c>] Requested symbol/channel pairs.</summary>
    [JsonPropertyName("args")]
    public BitunixSocketArgument[] Arguments { get; set; } = [];
}
