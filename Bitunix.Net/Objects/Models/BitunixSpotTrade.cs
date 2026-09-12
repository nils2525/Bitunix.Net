using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Public website spot fill.</summary>
public class BitunixSpotTrade
{
    /// <summary>[<c>id</c>] Native 64-bit trade identifier.</summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }
    /// <summary>[<c>ts</c>] Trade time.</summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
    /// <summary>[<c>price</c>] Fill price in quote units.</summary>
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    /// <summary>[<c>vol</c>] Filled base quantity.</summary>
    [JsonPropertyName("vol")]
    public decimal Quantity { get; set; }
    /// <summary>[<c>side</c>] Native buy/sell taker side, established by account-confirmed execution probes; the website protocol is undocumented.</summary>
    [JsonPropertyName("side")]
    public string Side { get; set; } = "";
}
