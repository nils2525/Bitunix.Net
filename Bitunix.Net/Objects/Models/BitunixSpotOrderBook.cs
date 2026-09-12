using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Public spot REST depth snapshot.</summary>
public class BitunixSpotOrderBook
{
    /// <summary>[<c>ts</c>] Native timestamp; empty when no book is available.</summary>
    [JsonPropertyName("ts")]
    public string Timestamp { get; set; } = "";
    /// <summary>[<c>asks</c>] Ask levels.</summary>
    [JsonPropertyName("asks")]
    public BitunixSpotOrderBookEntry[] Asks { get; set; } = [];
    /// <summary>[<c>bids</c>] Bid levels.</summary>
    [JsonPropertyName("bids")]
    public BitunixSpotOrderBookEntry[] Bids { get; set; } = [];
}
