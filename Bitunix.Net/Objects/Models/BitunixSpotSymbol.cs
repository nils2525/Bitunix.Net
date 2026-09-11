using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Bitunix spot trading pair metadata.</summary>
public class BitunixSpotSymbol
{
    /// <summary>[<c>id</c>] Trading pair identifier.</summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }
    /// <summary>[<c>symbol</c>] Native lowercase symbol, present in live responses.</summary>
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = "";
    /// <summary>[<c>base</c>] Base asset.</summary>
    [JsonPropertyName("base")]
    public string BaseAsset { get; set; } = "";
    /// <summary>[<c>quote</c>] Quote asset.</summary>
    [JsonPropertyName("quote")]
    public string QuoteAsset { get; set; } = "";
    /// <summary>[<c>basePrecision</c>] Base quantity decimal places.</summary>
    [JsonPropertyName("basePrecision")]
    public int? BasePrecision { get; set; }
    /// <summary>[<c>quotePrecision</c>] Order price decimal places.</summary>
    [JsonPropertyName("quotePrecision")]
    public int? QuotePrecision { get; set; }
    /// <summary>[<c>minPrice</c>] Minimum order value in quote asset units.</summary>
    [JsonPropertyName("minPrice")]
    public decimal? MinOrderValue { get; set; }
    /// <summary>[<c>minVolume</c>] Minimum base quantity.</summary>
    [JsonPropertyName("minVolume")]
    public decimal? MinQuantity { get; set; }
    /// <summary>[<c>isOpen</c>] Trading status: 0 closed, 1 open.</summary>
    [JsonPropertyName("isOpen")]
    public int? IsOpen { get; set; }
    /// <summary>[<c>isHot</c>] Trending flag, encoded as 0 or 1.</summary>
    [JsonPropertyName("isHot")]
    public int? IsHot { get; set; }
    /// <summary>[<c>isRecommend</c>] Recommended flag, encoded as 0 or 1.</summary>
    [JsonPropertyName("isRecommend")]
    public int? IsRecommended { get; set; }
    /// <summary>[<c>isShow</c>] Visibility flag, encoded as 0 or 1.</summary>
    [JsonPropertyName("isShow")]
    public int? IsVisible { get; set; }
    /// <summary>[<c>tradeArea</c>] Trading category.</summary>
    [JsonPropertyName("tradeArea")]
    public string? TradeArea { get; set; }
    /// <summary>[<c>sort</c>] Display order.</summary>
    [JsonPropertyName("sort")]
    public int? Sort { get; set; }
    /// <summary>[<c>openTime</c>] Native opening time; null when unavailable.</summary>
    [JsonPropertyName("openTime")]
    public string? OpenTime { get; set; }
    /// <summary>[<c>precisions</c>] Available depth aggregation precisions.</summary>
    [JsonPropertyName("precisions")]
    public string[]? Precisions { get; set; }
}
