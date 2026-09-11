using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Bitunix.Net.Objects.Models;
/// <summary>Bitunix OrderBook wire data.</summary>
public class BitunixOrderBook
{
    /// <summary>[<c>asks</c>] Ask [price, base quantity] levels.</summary>
    [JsonPropertyName("asks")]
    public decimal[][] Asks { get; set; } = [];
    /// <summary>[<c>bids</c>] Bid [price, base quantity] levels.</summary>
    [JsonPropertyName("bids")]
    public decimal[][] Bids { get; set; } = [];
}
