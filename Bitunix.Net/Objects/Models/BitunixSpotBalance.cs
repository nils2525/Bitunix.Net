using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>A spot asset balance and its funds locked in orders.</summary>
public class BitunixSpotBalance
{
    /// <summary>[<c>coin</c>] Asset code.</summary>
    [JsonPropertyName("coin")]
    public string Asset { get; set; } = "";
    /// <summary>[<c>balance</c>] Asset balance.</summary>
    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }
    /// <summary>[<c>balanceLocked</c>] Asset balance in use.</summary>
    [JsonPropertyName("balanceLocked")]
    public decimal Locked { get; set; }
}
