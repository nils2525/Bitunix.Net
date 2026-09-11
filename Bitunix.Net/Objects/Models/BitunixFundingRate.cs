using System.Text.Json.Serialization;

namespace Bitunix.Net.Objects.Models;

/// <summary>Current funding estimate and prices for one contract.</summary>
public class BitunixFundingRate
{
    /// <summary>[<c>symbol</c>] Native contract symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>markPrice</c>] Mark price.</summary>
    [JsonPropertyName("markPrice")]
    public decimal MarkPrice { get; set; }
    /// <summary>[<c>lastPrice</c>] Latest trade price.</summary>
    [JsonPropertyName("lastPrice")]
    public decimal LastPrice { get; set; }
    /// <summary>[<c>indexPrice</c>] Underlying index price; null when unavailable, as observed for TONUSD.</summary>
    [JsonPropertyName("indexPrice")]
    public decimal? IndexPrice { get; set; }
    /// <summary>[<c>fundingRate</c>] Current estimated rate in percentage points.</summary>
    [JsonPropertyName("fundingRate")]
    public decimal FundingRate { get; set; }
    /// <summary>[<c>nextFundingTime</c>] Next settlement time, UTC; native milliseconds as a number or string.</summary>
    [JsonPropertyName("nextFundingTime")]
    public DateTime NextFundingTime { get; set; }
    /// <summary>[<c>fundingInterval</c>] Settlement interval in hours.</summary>
    [JsonPropertyName("fundingInterval")]
    public int FundingInterval { get; set; }
    /// <summary>[<c>maxFundingRate</c>] Upper rate bound in percentage points.</summary>
    [JsonPropertyName("maxFundingRate")]
    public decimal MaxFundingRate { get; set; }
    /// <summary>[<c>minFundingRate</c>] Lower rate bound in percentage points.</summary>
    [JsonPropertyName("minFundingRate")]
    public decimal MinFundingRate { get; set; }
}
