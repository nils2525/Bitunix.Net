using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Page of closed futures positions.</summary>
public class BitunixPositionHistoryPage
{
    /// <summary>[<c>positionList</c>] Closed positions.</summary>
    [JsonPropertyName("positionList")]
    public BitunixPositionHistory[] Positions { get; set; } = [];
    /// <summary>[<c>total</c>] Total matching position count.</summary>
    [JsonPropertyName("total")]
    public long Total { get; set; }
}

