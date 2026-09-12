using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Page of futures orders.</summary>
public class BitunixOrderPage
{
    /// <summary>[<c>orderList</c>] Orders sorted by descending creation time.</summary>
    [JsonPropertyName("orderList")]
    public BitunixOrder[] Orders { get; set; } = [];
    /// <summary>[<c>total</c>] Total matching order count.</summary>
    [JsonPropertyName("total")]
    public long Total { get; set; }
}

