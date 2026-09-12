using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net.Interfaces.Clients.SpotApi;
/// <summary>Public spot market data.</summary>
public interface IBitunixRestClientSpotApiExchangeData
{
    /// <summary>Gets all spot trading pairs. <see href="https://www.bitunix.com/api-docs/spots/en_us/public/#5-query-trading-pair-data" /></summary>
    Task<HttpResult<BitunixSpotSymbol[]>> GetSymbolsAsync(CancellationToken ct = default);
    /// <summary>Gets spot depth. Precision is a price increment such as 0.01, verified live, not a decimal count. <see href="https://www.bitunix.com/api-docs/spots/en_us/public/#2-get-depth-data" /></summary>
    Task<HttpResult<BitunixSpotOrderBook>> GetOrderBookAsync(string symbol, decimal precision, CancellationToken ct = default);
}
