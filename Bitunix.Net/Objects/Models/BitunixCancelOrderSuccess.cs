using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Accepted order cancellation.</summary>
public class BitunixCancelOrderSuccess
{
    /// <summary>[<c>id</c>] Order identifier documented in the response table.</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    /// <summary>[<c>orderId</c>] Order identifier shown in the documented example.</summary>
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }
    /// <summary>[<c>clientId</c>] Client-provided order identifier.</summary>
    [JsonPropertyName("clientId")]
    public string? ClientOrderId { get; set; }
}

