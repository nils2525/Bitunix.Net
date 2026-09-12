using System.Text.Json.Serialization;
using Bitunix.Net.Objects.Models;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>One subscribed spot channel in a website frame.</summary>
internal sealed class BitunixSpotSocketItem
{
    /// <summary>[<c>channel</c>] Lowercase native channel.</summary>
    [JsonPropertyName("channel")]
    public string Channel { get; set; } = "";
    /// <summary>[<c>market_message_type</c>] Native payload discriminator.</summary>
    [JsonPropertyName("market_message_type")]
    public int MessageType { get; set; }
    /// <summary>[<c>market</c>] Rolling statistics, present for spot_market channels.</summary>
    [JsonPropertyName("market")]
    public BitunixSpotTicker? Market { get; set; }
    /// <summary>[<c>deals</c>] Trades, present for spot_deals channels.</summary>
    [JsonPropertyName("deals")]
    public BitunixSpotTradeUpdate? Deals { get; set; }
    /// <summary>[<c>bestPrice</c>] Exact best prices and quantities, present for spot_best_price channels.</summary>
    [JsonPropertyName("bestPrice")]
    public BitunixSpotBestPrice? BestPrice { get; set; }
}
