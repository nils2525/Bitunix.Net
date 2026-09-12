using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Changed account position mode.</summary>
public class BitunixPositionMode
{
    /// <summary>[<c>positionMode</c>] ONE_WAY or HEDGE.</summary>
    [JsonPropertyName("positionMode")]
    public string PositionMode { get; set; } = "";
}

