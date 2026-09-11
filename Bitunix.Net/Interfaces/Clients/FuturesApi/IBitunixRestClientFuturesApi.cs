using CryptoExchange.Net.Interfaces.Clients;
namespace Bitunix.Net.Interfaces.Clients.FuturesApi;
/// <summary>Bitunix futures REST API.</summary>
public interface IBitunixRestClientFuturesApi : IRestApiClient<BitunixCredentials>
{
    /// <summary>Market data endpoints.</summary>
    IBitunixRestClientFuturesApiExchangeData ExchangeData { get; }
}
