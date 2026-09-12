using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Accepted and rejected cancellations.</summary>
public class BitunixCancelOrdersResult
{
    /// <summary>[<c>successList</c>] Accepted requests.</summary>
    [JsonPropertyName("successList")]
    public BitunixCancelOrderSuccess[] Success { get; set; } = [];
    /// <summary>[<c>failureList</c>] Rejected requests.</summary>
    [JsonPropertyName("failureList")]
    public BitunixCancelOrderFailure[] Failure { get; set; } = [];
}

