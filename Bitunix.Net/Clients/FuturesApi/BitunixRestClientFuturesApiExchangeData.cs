using Bitunix.Net.Interfaces.Clients.FuturesApi;
using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net.Clients.FuturesApi;
/// <inheritdoc />
internal sealed class BitunixRestClientFuturesApiExchangeData(BitunixRestClientFuturesApi client) : IBitunixRestClientFuturesApiExchangeData
{
    #region Statics
    private static readonly RequestDefinitionCache Definitions = new();
    #endregion

    #region Methods
    private Task<HttpResult<T>> GetAsync<T>(string path, Parameters parameters, CancellationToken ct)
    {
        var definition = Definitions.GetOrCreate(HttpMethod.Get, client.BaseAddress, "/api/v1/futures/market/" + path, BitunixExchange.RateLimiter.Rest, 1, false);
        return client.SendAsync<T>(definition, parameters, ct);
    }
    private static Parameters SymbolParameters(IEnumerable<string>? symbols)
    {
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        if (symbols != null)
            parameters.Add("symbols", string.Join(",", symbols));
        return parameters;
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixSymbol[]>> GetSymbolsAsync(IEnumerable<string>? symbols = null, CancellationToken ct = default) => GetAsync<BitunixSymbol[]>("trading_pairs", SymbolParameters(symbols), ct);
    /// <inheritdoc />
    public Task<HttpResult<BitunixTicker[]>> GetTickersAsync(IEnumerable<string>? symbols = null, CancellationToken ct = default) => GetAsync<BitunixTicker[]>("tickers", SymbolParameters(symbols), ct);
    /// <inheritdoc />
    public Task<HttpResult<BitunixFundingRate[]>> GetFundingRatesAsync(CancellationToken ct = default) => GetAsync<BitunixFundingRate[]>("funding_rate/batch", new Parameters(BitunixExchange.ParameterSettings), ct);
    /// <inheritdoc />
    public Task<HttpResult<BitunixOrderBook>> GetOrderBookAsync(string symbol, string limit = "1", CancellationToken ct = default)
    {
        if (limit is not ("1" or "5" or "15" or "50" or "max"))
            throw new ArgumentOutOfRangeException(nameof(limit));
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        parameters.Add("symbol", symbol);
        parameters.Add("limit", limit);
        return GetAsync<BitunixOrderBook>("depth", parameters, ct);
    }
    #endregion
}
