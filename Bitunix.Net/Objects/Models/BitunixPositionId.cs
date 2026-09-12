using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Closed position identifier.</summary>
public class BitunixPositionId
{
    /// <summary>[<c>positionId</c>] Exchange position identifier.</summary>
    [JsonPropertyName("positionId")]
    public string PositionId { get; set; } = "";
}

