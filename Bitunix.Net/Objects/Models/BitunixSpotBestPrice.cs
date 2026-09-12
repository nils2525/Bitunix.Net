using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Exact top-of-book prices and base quantities from the public spot best-price stream.</summary>
public class BitunixSpotBestPrice
{
    /// <summary>[<c>ts</c>] Book timestamp.</summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>bid</c>] Highest buy price.</summary>
    [JsonPropertyName("bid")]
    public decimal BidPrice { get; set; }
    /// <summary>[<c>ask</c>] Lowest sell price.</summary>
    [JsonPropertyName("ask")]
    public decimal AskPrice { get; set; }
    /// <summary>[<c>bidSize</c>] Base quantity available at the best bid.</summary>
    [JsonPropertyName("bidSize")]
    public decimal BidSize { get; set; }
    /// <summary>[<c>askSize</c>] Base quantity available at the best ask.</summary>
    [JsonPropertyName("askSize")]
    public decimal AskSize { get; set; }
}
