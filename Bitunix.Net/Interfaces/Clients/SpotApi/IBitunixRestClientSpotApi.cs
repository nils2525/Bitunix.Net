using CryptoExchange.Net.Interfaces.Clients;
namespace Bitunix.Net.Interfaces.Clients.SpotApi;
/// <summary>Bitunix spot REST API.</summary>
public interface IBitunixRestClientSpotApi : IRestApiClient<BitunixCredentials>
{
    /// <summary>Market data endpoints.</summary>
    IBitunixRestClientSpotApiExchangeData ExchangeData { get; }
    /// <summary>Authenticated spot balances, user information and wallet transfers.</summary>
    IBitunixRestClientSpotApiAccount Account { get; }
}
