using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitunix.Net.Objects.Models;
/// <summary>Bitunix TickerUpdate wire data.</summary>
public class BitunixTickerUpdate
{
    /// <summary>[<c>s</c>] Native symbol.</summary>
    [JsonPropertyName("s")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>o</c>] 24-hour open.</summary>
    [JsonPropertyName("o")]
    public decimal OpenPrice { get; set; }
    /// <summary>[<c>h</c>] 24-hour high.</summary>
    [JsonPropertyName("h")]
    public decimal HighPrice { get; set; }
    /// <summary>[<c>l</c>] 24-hour low.</summary>
    [JsonPropertyName("l")]
    public decimal LowPrice { get; set; }
    /// <summary>[<c>la</c>] Last traded price.</summary>
    [JsonPropertyName("la")]
    public decimal LastPrice { get; set; }
    /// <summary>[<c>b</c>] 24-hour base volume.</summary>
    [JsonPropertyName("b")]
    public decimal BaseVolume { get; set; }
    /// <summary>[<c>q</c>] 24-hour quote volume.</summary>
    [JsonPropertyName("q")]
    public decimal QuoteVolume { get; set; }
    /// <summary>[<c>r</c>] 24-hour change in percentage points.</summary>
    [JsonPropertyName("r")]
    public decimal ChangePercentage { get; set; }
    /// <summary>[<c>bd</c>] Best bid price.</summary>
    [JsonPropertyName("bd")]
    public decimal BestBidPrice { get; set; }
    /// <summary>[<c>ak</c>] Best ask price.</summary>
    [JsonPropertyName("ak")]
    public decimal BestAskPrice { get; set; }
    /// <summary>[<c>bv</c>] Best bid base quantity.</summary>
    [JsonPropertyName("bv")]
    public decimal BestBidQuantity { get; set; }
    /// <summary>[<c>av</c>] Best ask base quantity.</summary>
    [JsonPropertyName("av")]
    public decimal BestAskQuantity { get; set; }
}
