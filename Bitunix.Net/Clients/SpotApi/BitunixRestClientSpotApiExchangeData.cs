using Bitunix.Net.Interfaces.Clients.SpotApi;
using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net.Clients.SpotApi;
/// <inheritdoc />
internal sealed class BitunixRestClientSpotApiExchangeData(BitunixRestClientSpotApi client) : IBitunixRestClientSpotApiExchangeData
{
    #region Statics
    private static readonly RequestDefinitionCache Definitions = new();
    #endregion

    #region Methods
    /// <inheritdoc />
    public Task<HttpResult<BitunixSpotSymbol[]>> GetSymbolsAsync(CancellationToken ct = default)
    {
        var definition = Definitions.GetOrCreate(HttpMethod.Get, client.BaseAddress, "/api/spot/v1/common/coin_pair/list", BitunixExchange.RateLimiter.SpotRest, 1, false);
        return client.SendAsync<BitunixSpotSymbol[]>(definition, new Parameters(BitunixExchange.ParameterSettings), ct);
    }
    #endregion
}
