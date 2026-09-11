using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitunix.Net.Objects.Models;
/// <summary>Bitunix Symbol wire data.</summary>
public class BitunixSymbol
{
    /// <summary>[<c>symbol</c>] Native symbol.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>base</c>] Base asset.</summary>
    [JsonPropertyName("base")]
    public string BaseAsset { get; set; } = "";
    /// <summary>[<c>quote</c>] Quote asset; also the settlement asset for linear contracts.</summary>
    [JsonPropertyName("quote")]
    public string QuoteAsset { get; set; } = "";
    /// <summary>[<c>minTradeVolume</c>] Minimum opening quantity, in base units for linear contracts.</summary>
    [JsonPropertyName("minTradeVolume")]
    public decimal MinTradeVolume { get; set; }
    /// <summary>[<c>minBuyPriceOffset</c>] Minimum buy price offset; null when unavailable.</summary>
    [JsonPropertyName("minBuyPriceOffset")]
    public decimal? MinBuyPriceOffset { get; set; }
    /// <summary>[<c>maxSellPriceOffset</c>] Maximum sell price offset; null when unavailable.</summary>
    [JsonPropertyName("maxSellPriceOffset")]
    public decimal? MaxSellPriceOffset { get; set; }
    /// <summary>[<c>maxLimitOrderVolume</c>] Maximum limit order quantity, in base units for linear contracts.</summary>
    [JsonPropertyName("maxLimitOrderVolume")]
    public decimal MaxLimitOrderVolume { get; set; }
    /// <summary>[<c>maxMarketOrderVolume</c>] Maximum market order quantity, in base units for linear contracts.</summary>
    [JsonPropertyName("maxMarketOrderVolume")]
    public decimal MaxMarketOrderVolume { get; set; }
    /// <summary>[<c>basePrecision</c>] Quantity decimal places.</summary>
    [JsonPropertyName("basePrecision")]
    public int BasePrecision { get; set; }
    /// <summary>[<c>quotePrecision</c>] Price decimal places.</summary>
    [JsonPropertyName("quotePrecision")]
    public int QuotePrecision { get; set; }
    /// <summary>[<c>maxLeverage</c>] Maximum leverage.</summary>
    [JsonPropertyName("maxLeverage")]
    public int MaxLeverage { get; set; }
    /// <summary>[<c>minLeverage</c>] Minimum leverage.</summary>
    [JsonPropertyName("minLeverage")]
    public int MinLeverage { get; set; }
    /// <summary>[<c>defaultLeverage</c>] Default leverage.</summary>
    [JsonPropertyName("defaultLeverage")]
    public int DefaultLeverage { get; set; }
    /// <summary>[<c>defaultMarginMode</c>] Native margin mode; live API returns a numeric string.</summary>
    [JsonPropertyName("defaultMarginMode")]
    [JsonConverter(typeof(Bitunix.Net.Converters.BitunixStringConverter))]
    public string DefaultMarginMode { get; set; } = "";
    /// <summary>[<c>priceProtectScope</c>] Mark price protection fraction.</summary>
    [JsonPropertyName("priceProtectScope")]
    public decimal PriceProtectScope { get; set; }
    /// <summary>[<c>symbolStatus</c>] OPEN, CANCEL_ONLY, STOP or the observed PREVIEW status.</summary>
    [JsonPropertyName("symbolStatus")]
    public string SymbolStatus { get; set; } = "";
    /// <summary>[<c>isApiSupported</c>] Whether API trading is enabled.</summary>
    [JsonPropertyName("isApiSupported")]
    public bool IsApiSupported { get; set; }
    /// <summary>[<c>maxFundingRate</c>] Funding upper limit in percentage points.</summary>
    [JsonPropertyName("maxFundingRate")]
    public decimal MaxFundingRate { get; set; }
    /// <summary>[<c>minFundingRate</c>] Funding lower limit in percentage points.</summary>
    [JsonPropertyName("minFundingRate")]
    public decimal MinFundingRate { get; set; }
}
