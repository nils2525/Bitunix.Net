using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Typed channel envelope.</summary>
internal class BitunixSocketEvent<T> : BitunixSocketEvent
{
    /// <summary>[<c>data</c>] Channel payload.</summary>
    [JsonPropertyName("data")]
    public T Data { get; set; } = default!;
}
