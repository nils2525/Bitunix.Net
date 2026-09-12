using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Futures account balance update.</summary>
public class BitunixBalanceUpdate
{
    /// <summary>[<c>coin</c>] Margin asset.</summary>
    [JsonPropertyName("coin")]
    public string Coin { get; set; } = "";
    /// <summary>[<c>available</c>] Available balance.</summary>
    [JsonPropertyName("available")]
    public decimal Available { get; set; }
    /// <summary>[<c>frozen</c>] Total frozen balance.</summary>
    [JsonPropertyName("frozen")]
    public decimal Frozen { get; set; }
    /// <summary>[<c>isolationFrozen</c>] Balance frozen for isolated orders.</summary>
    [JsonPropertyName("isolationFrozen")]
    public decimal IsolatedFrozen { get; set; }
    /// <summary>[<c>crossFrozen</c>] Balance frozen for cross orders.</summary>
    [JsonPropertyName("crossFrozen")]
    public decimal CrossFrozen { get; set; }
    /// <summary>[<c>margin</c>] Position margin.</summary>
    [JsonPropertyName("margin")]
    public decimal Margin { get; set; }
    /// <summary>[<c>isolationMargin</c>] Isolated position margin.</summary>
    [JsonPropertyName("isolationMargin")]
    public decimal IsolatedMargin { get; set; }
    /// <summary>[<c>crossMargin</c>] Cross position margin.</summary>
    [JsonPropertyName("crossMargin")]
    public decimal CrossMargin { get; set; }
    /// <summary>[<c>expMoney</c>] Trial funds.</summary>
    [JsonPropertyName("expMoney")]
    public decimal ExperienceMoney { get; set; }
}
