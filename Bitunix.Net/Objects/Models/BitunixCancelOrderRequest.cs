using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Order identifier supplied for cancellation.</summary>
public class BitunixCancelOrderRequest
{
    /// <summary>[<c>orderId</c>] Exchange order identifier; takes precedence over clientId.</summary>
    [JsonPropertyName("orderId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OrderId { get; set; }
    /// <summary>[<c>clientId</c>] Client-provided order identifier.</summary>
    [JsonPropertyName("clientId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ClientOrderId { get; set; }
}

