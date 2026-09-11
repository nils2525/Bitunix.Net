using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitunix.Net.Objects.Models;
/// <summary>Bitunix Trade wire data.</summary>
public class BitunixTrade
{
    /// <summary>[<c>p</c>] Fill price.</summary>
    [JsonPropertyName("p")]
    public decimal Price { get; set; }
    /// <summary>[<c>v</c>] Filled base quantity.</summary>
    [JsonPropertyName("v")]
    public decimal Quantity { get; set; }
    /// <summary>[<c>s</c>] Native filled side, buy or sell.</summary>
    [JsonPropertyName("s")]
    public string Side { get; set; } = "";
    /// <summary>[<c>t</c>] Fill time in UTC.</summary>
    [JsonPropertyName("t")]
    public DateTime Timestamp { get; set; }
}
