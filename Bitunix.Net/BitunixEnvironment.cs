using CryptoExchange.Net.Objects;
namespace Bitunix.Net;
/// <summary>Bitunix market data and authenticated API environments.</summary>
public class BitunixEnvironment : TradeEnvironment
{
    /// <summary>Futures REST API address.</summary>
    public string RestClientAddress { get; } = "https://fapi.bitunix.com";
    /// <summary>Spot REST API address.</summary>
    public string SpotRestClientAddress { get; } = "https://openapi.bitunix.com";
    /// <summary>Public WebSocket address.</summary>
    public string SocketClientAddress { get; } = "wss://fapi.bitunix.com/public/";
    /// <summary>Authenticated WebSocket address.</summary>
    public string PrivateSocketClientAddress { get; } = "wss://fapi.bitunix.com/private/";
    /// <summary>Live environment.</summary>
    public static BitunixEnvironment Live { get; } = new();
    /// <summary>Available environment names.</summary>
    public static string[] All => [Live.Name];
    /// <summary>Creates the live environment for configuration binding.</summary>
    public BitunixEnvironment() : base(TradeEnvironmentNames.Live) { }
    private BitunixEnvironment(string name, string restAddress, string socketAddress, string spotRestAddress, string privateSocketAddress) : base(name)
    {
        RestClientAddress = restAddress;
        SocketClientAddress = socketAddress;
        SpotRestClientAddress = spotRestAddress;
        PrivateSocketClientAddress = privateSocketAddress;
    }
    /// <summary>Creates an explicit custom environment, including local test servers.</summary>
    public static BitunixEnvironment CreateCustom(string name, string restAddress, string socketAddress, string? spotRestAddress = null, string? privateSocketAddress = null) => new(name, restAddress, socketAddress, spotRestAddress ?? restAddress, privateSocketAddress ?? socketAddress);
}
