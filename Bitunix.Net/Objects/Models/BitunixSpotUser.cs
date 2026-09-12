using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>The user associated with the spot API key.</summary>
public class BitunixSpotUser
{
    /// <summary>[<c>uid</c>] Master user ID, including for a sub-account key; can be null.</summary>
    [JsonPropertyName("uid")]
    public long? UserId { get; set; }
}
