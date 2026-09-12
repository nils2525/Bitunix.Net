using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Rejected order cancellation.</summary>
public class BitunixCancelOrderFailure
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
    /// <summary>[<c>errorMsg</c>] Rejection reason.</summary>
    [JsonPropertyName("errorMsg")]
    public string ErrorMessage { get; set; } = "";
    /// <summary>[<c>errorCode</c>] Error code; the official example uses a JSON number.</summary>
    [JsonPropertyName("errorCode")]
    [JsonConverter(typeof(Bitunix.Net.Converters.BitunixStringConverter))]
    public string ErrorCode { get; set; } = "";
}

