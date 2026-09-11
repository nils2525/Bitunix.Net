using CryptoExchange.Net.Interfaces.Clients;
using Bitunix.Net.Interfaces.Clients.FuturesApi;
namespace Bitunix.Net.Interfaces.Clients;
/// <summary>Bitunix public WebSocket client.</summary>
public interface IBitunixSocketClient : ISocketClient<BitunixCredentials>
{
    /// <summary>Public futures streams.</summary>
    IBitunixSocketClientFuturesApi FuturesApi { get; }
}
