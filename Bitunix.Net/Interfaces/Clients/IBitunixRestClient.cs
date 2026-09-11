using CryptoExchange.Net.Interfaces.Clients;
using Bitunix.Net.Interfaces.Clients.FuturesApi;
using Bitunix.Net.Interfaces.Clients.SpotApi;
namespace Bitunix.Net.Interfaces.Clients;
/// <summary>Bitunix public REST client.</summary>
public interface IBitunixRestClient : IRestClient<BitunixCredentials>
{
    /// <summary>Public futures endpoints.</summary>
    IBitunixRestClientFuturesApi FuturesApi { get; }
    /// <summary>Public spot endpoints.</summary>
    IBitunixRestClientSpotApi SpotApi { get; }
}
