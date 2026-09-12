using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Futures socket depth snapshot with quantities in base asset.</summary>
public class BitunixOrderBookUpdate
{
    /// <summary>[<c>a</c>] Ask price and base quantity levels.</summary>
    [JsonPropertyName("a")]
    public BitunixOrderBookEntry[] Asks { get; set; } = [];
    /// <summary>[<c>b</c>] Bid price and base quantity levels.</summary>
    [JsonPropertyName("b")]
    public BitunixOrderBookEntry[] Bids { get; set; } = [];
}
