using System.Text.Json.Serialization;
namespace Bitunix.Net.Objects.Models;
/// <summary>Futures account balances and position mode.</summary>
public class BitunixAccount
{
    /// <summary>[<c>marginCoin</c>] Settlement asset.</summary>
    [JsonPropertyName("marginCoin")]
    public string MarginAsset { get; set; } = "";
    /// <summary>[<c>available</c>] Available balance; add cross unrealized profit for the maximum opening amount.</summary>
    [JsonPropertyName("available")]
    public decimal Available { get; set; }
    /// <summary>[<c>frozen</c>] Balance locked by orders.</summary>
    [JsonPropertyName("frozen")]
    public decimal Frozen { get; set; }
    /// <summary>[<c>margin</c>] Balance locked by positions.</summary>
    [JsonPropertyName("margin")]
    public decimal Margin { get; set; }
    /// <summary>[<c>transfer</c>] Maximum transferable balance.</summary>
    [JsonPropertyName("transfer")]
    public decimal Transfer { get; set; }
    /// <summary>[<c>positionMode</c>] ONE_WAY or HEDGE.</summary>
    [JsonPropertyName("positionMode")]
    public string PositionMode { get; set; } = "";
    /// <summary>[<c>crossUnrealizedPNL</c>] Unrealized profit on cross positions.</summary>
    [JsonPropertyName("crossUnrealizedPNL")]
    public decimal CrossUnrealizedPnl { get; set; }
    /// <summary>[<c>isolationUnrealizedPNL</c>] Unrealized profit on isolated positions.</summary>
    [JsonPropertyName("isolationUnrealizedPNL")]
    public decimal IsolatedUnrealizedPnl { get; set; }
    /// <summary>[<c>bonus</c>] Futures bonus balance.</summary>
    [JsonPropertyName("bonus")]
    public decimal Bonus { get; set; }
}

