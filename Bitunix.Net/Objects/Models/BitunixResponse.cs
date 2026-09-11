using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Bitunix REST status envelope.</summary>
internal class BitunixResponse
{
    /// <summary>[<c>code</c>] Zero indicates success.</summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }
    /// <summary>[<c>msg</c>] Native status description.</summary>
    [JsonPropertyName("msg")]
    public string Message { get; set; } = "";
}
