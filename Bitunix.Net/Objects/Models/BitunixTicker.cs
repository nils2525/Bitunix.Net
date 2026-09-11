using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitunix.Net.Objects.Models;
/// <summary>Bitunix Ticker wire data.</summary>
public class BitunixTicker
{
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>markPrice</c>] Mark price.</summary>
    [JsonPropertyName("markPrice")]
    public decimal MarkPrice { get; set; }
    /// <summary>[<c>lastPrice</c>] Latest traded price.</summary>
    [JsonPropertyName("lastPrice")]
    public decimal LastPrice { get; set; }
    /// <summary>[<c>open</c>] 24-hour opening price.</summary>
    [JsonPropertyName("open")]
    public decimal OpenPrice { get; set; }
    /// <summary>[<c>last</c>] Last price in the rolling ticker.</summary>
    [JsonPropertyName("last")]
    public decimal Last { get; set; }
    /// <summary>[<c>quoteVol</c>] 24-hour quote volume.</summary>
    [JsonPropertyName("quoteVol")]
    public decimal QuoteVolume { get; set; }
    /// <summary>[<c>baseVol</c>] 24-hour base volume.</summary>
    [JsonPropertyName("baseVol")]
    public decimal BaseVolume { get; set; }
    /// <summary>[<c>high</c>] 24-hour high.</summary>
    [JsonPropertyName("high")]
    public decimal HighPrice { get; set; }
    /// <summary>[<c>low</c>] 24-hour low.</summary>
    [JsonPropertyName("low")]
    public decimal LowPrice { get; set; }
}
