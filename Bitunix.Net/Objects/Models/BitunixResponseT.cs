using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Bitunix REST data envelope.</summary>
internal class BitunixResponse<T> : BitunixResponse
{
    /// <summary>[<c>data</c>] Endpoint response data.</summary>
    [JsonPropertyName("data")]
    public T Data { get; set; } = default!;
}
