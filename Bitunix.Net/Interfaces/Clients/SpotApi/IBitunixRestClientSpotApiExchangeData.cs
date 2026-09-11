using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net.Interfaces.Clients.SpotApi;
/// <summary>Public spot market data.</summary>
public interface IBitunixRestClientSpotApiExchangeData
{
    /// <summary>Gets all spot trading pairs. <see href="https://www.bitunix.com/api-docs/spots/en_us/public/#5-query-trading-pair-data" /></summary>
    Task<HttpResult<BitunixSpotSymbol[]>> GetSymbolsAsync(CancellationToken ct = default);
}
