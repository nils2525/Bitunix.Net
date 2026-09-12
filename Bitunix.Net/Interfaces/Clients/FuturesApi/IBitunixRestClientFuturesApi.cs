using CryptoExchange.Net.Interfaces.Clients;
namespace Bitunix.Net.Interfaces.Clients.FuturesApi;
/// <summary>Bitunix futures REST API.</summary>
public interface IBitunixRestClientFuturesApi : IRestApiClient<BitunixCredentials>
{
    /// <summary>Market data endpoints.</summary>
    IBitunixRestClientFuturesApiExchangeData ExchangeData { get; }
    /// <summary>Futures account balances and configuration.</summary>
    IBitunixRestClientFuturesApiAccount Account { get; }
    /// <summary>Futures orders, fills and positions.</summary>
    IBitunixRestClientFuturesApiTrading Trading { get; }
}
