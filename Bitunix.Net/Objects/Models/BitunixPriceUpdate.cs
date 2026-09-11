using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitunix.Net.Objects.Models;
/// <summary>Bitunix PriceUpdate wire data.</summary>
public class BitunixPriceUpdate
{
    /// <summary>[<c>mp</c>] Mark price.</summary>
    [JsonPropertyName("mp")]
    public decimal MarkPrice { get; set; }
    /// <summary>[<c>ip</c>] Underlying index price.</summary>
    [JsonPropertyName("ip")]
    public decimal IndexPrice { get; set; }
    /// <summary>[<c>fr</c>] Last settled funding rate in percentage points; differs from the current REST estimate.</summary>
    [JsonPropertyName("fr")]
    public decimal LastFundingRate { get; set; }
    /// <summary>[<c>ft</c>] Previous funding settlement time, UTC.</summary>
    [JsonPropertyName("ft")]
    public DateTime FundingTime { get; set; }
    /// <summary>[<c>nft</c>] Next funding settlement time, UTC.</summary>
    [JsonPropertyName("nft")]
    public DateTime NextFundingTime { get; set; }
}
