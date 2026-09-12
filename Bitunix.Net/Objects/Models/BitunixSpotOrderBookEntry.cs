using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>One public spot REST depth level.</summary>
public class BitunixSpotOrderBookEntry
{
    /// <summary>[<c>price</c>] Price in quote units.</summary>
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    /// <summary>[<c>volume</c>] Base quantity at this price.</summary>
    [JsonPropertyName("volume")]
    public decimal Quantity { get; set; }
}
