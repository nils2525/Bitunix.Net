using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net.Interfaces.Clients.FuturesApi;
/// <summary>Public futures market data.</summary>
public interface IBitunixRestClientFuturesApiExchangeData
{
    /// <summary>Gets trading pairs. <see href="https://www.bitunix.com/api-docs/futures/market/get_trading_pairs.html" /></summary>
    Task<HttpResult<BitunixSymbol[]>> GetSymbolsAsync(IEnumerable<string>? symbols = null, CancellationToken ct = default);
    /// <summary>Gets rolling tickers. <see href="https://www.bitunix.com/api-docs/futures/market/get_tickers.html" /></summary>
    Task<HttpResult<BitunixTicker[]>> GetTickersAsync(IEnumerable<string>? symbols = null, CancellationToken ct = default);
    /// <summary>Gets current funding estimates for all contracts. <see href="https://www.bitunix.com/api-docs/futures/market/get_funding_rate_batch.html" /></summary>
    Task<HttpResult<BitunixFundingRate[]>> GetFundingRatesAsync(CancellationToken ct = default);
    /// <summary>Gets order-book levels. <see href="https://www.bitunix.com/api-docs/futures/market/get_depth.html" /></summary>
    Task<HttpResult<BitunixOrderBook>> GetOrderBookAsync(string symbol, string limit = "1", CancellationToken ct = default);
}
