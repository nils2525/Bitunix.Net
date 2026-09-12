using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Submitted order identifiers.</summary>
public class BitunixOrderId
{
    /// <summary>[<c>orderId</c>] Exchange order identifier.</summary>
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; } = "";
    /// <summary>[<c>clientId</c>] Client-provided order identifier.</summary>
    [JsonPropertyName("clientId")]
    public string? ClientOrderId { get; set; }
}

