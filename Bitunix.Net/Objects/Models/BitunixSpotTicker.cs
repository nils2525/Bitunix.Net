using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Rolling 24-hour spot market statistics from the public website feed.</summary>
public class BitunixSpotTicker
{
    /// <summary>[<c>ts</c>] Market timestamp.</summary>
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; set; }
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>open</c>] Opening price of the rolling window.</summary>
    [JsonPropertyName("open")]
    public decimal OpenPrice { get; set; }
    /// <summary>[<c>close</c>] Last traded price.</summary>
    [JsonPropertyName("close")]
    public decimal LastPrice { get; set; }
    /// <summary>[<c>high</c>] Highest price in the rolling window.</summary>
    [JsonPropertyName("high")]
    public decimal HighPrice { get; set; }
    /// <summary>[<c>low</c>] Lowest price in the rolling window.</summary>
    [JsonPropertyName("low")]
    public decimal LowPrice { get; set; }
    /// <summary>[<c>volume</c>] Traded base quantity over 24 hours.</summary>
    [JsonPropertyName("volume")]
    public decimal BaseVolume { get; set; }
    /// <summary>[<c>amount</c>] Quote turnover over 24 hours.</summary>
    [JsonPropertyName("amount")]
    public decimal QuoteVolume { get; set; }
    /// <summary>[<c>rose24h</c>] 24-hour change in percentage points.</summary>
    [JsonPropertyName("rose24h")]
    public decimal ChangePercentage { get; set; }
}
