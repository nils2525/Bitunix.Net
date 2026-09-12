using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Page of account futures fills.</summary>
public class BitunixUserTradePage
{
    /// <summary>[<c>tradeList</c>] Fills sorted by descending creation time.</summary>
    [JsonPropertyName("tradeList")]
    public BitunixUserTrade[] Trades { get; set; } = [];
    /// <summary>[<c>total</c>] Total matching fill count.</summary>
    [JsonPropertyName("total")]
    public long Total { get; set; }
}

