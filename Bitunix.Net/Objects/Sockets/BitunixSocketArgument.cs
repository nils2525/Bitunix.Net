using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Native symbol/channel pair.</summary>
internal class BitunixSocketArgument
{
    /// <summary>[<c>ch</c>] Channel name.</summary>
    [JsonPropertyName("ch")]
    public string Channel { get; set; } = "";
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
}
