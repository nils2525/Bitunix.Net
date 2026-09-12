using CryptoExchange.Net.Interfaces.Clients;
using Bitunix.Net.Interfaces.Clients.FuturesApi;
using Bitunix.Net.Interfaces.Clients.SpotApi;
namespace Bitunix.Net.Interfaces.Clients;
/// <summary>Bitunix public WebSocket client.</summary>
public interface IBitunixSocketClient : ISocketClient<BitunixCredentials>
{
    /// <summary>Public futures streams.</summary>
    IBitunixSocketClientFuturesApi FuturesApi { get; }
    /// <summary>Public spot website streams.</summary>
    IBitunixSocketClientSpotApi SpotApi { get; }
}
