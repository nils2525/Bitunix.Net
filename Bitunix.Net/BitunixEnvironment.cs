using CryptoExchange.Net.Objects;
namespace Bitunix.Net;
/// <summary>Bitunix public API environments.</summary>
public class BitunixEnvironment : TradeEnvironment
{
    /// <summary>Futures REST API address.</summary>
    public string RestClientAddress { get; } = "https://fapi.bitunix.com";
    /// <summary>Spot REST API address.</summary>
    public string SpotRestClientAddress { get; } = "https://openapi.bitunix.com";
    /// <summary>Public WebSocket address.</summary>
    public string SocketClientAddress { get; } = "wss://fapi.bitunix.com/public/";
    /// <summary>Live environment.</summary>
    public static BitunixEnvironment Live { get; } = new();
    /// <summary>Available environment names.</summary>
    public static string[] All => [Live.Name];
    /// <summary>Creates the live environment for configuration binding.</summary>
    public BitunixEnvironment() : base(TradeEnvironmentNames.Live) { }
    private BitunixEnvironment(string name, string restAddress, string socketAddress, string spotRestAddress) : base(name)
    {
        RestClientAddress = restAddress;
        SocketClientAddress = socketAddress;
        SpotRestClientAddress = spotRestAddress;
    }
    /// <summary>Creates an explicit custom environment, including local test servers.</summary>
    public static BitunixEnvironment CreateCustom(string name, string restAddress, string socketAddress, string? spotRestAddress = null) => new(name, restAddress, socketAddress, spotRestAddress ?? restAddress);
}
