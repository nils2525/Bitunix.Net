using Bitunix.Net.Interfaces.Clients.FuturesApi;
using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net.Clients.FuturesApi;
/// <inheritdoc />
internal sealed class BitunixRestClientFuturesApiAccount(BitunixRestClientFuturesApi client) : IBitunixRestClientFuturesApiAccount
{
    #region Statics
    private static readonly RequestDefinitionCache Definitions = new();
    #endregion

    #region Methods
    private Task<HttpResult<T>> SendAsync<T>(HttpMethod method, string path, Parameters parameters, CancellationToken ct)
    {
        var definition = Definitions.GetOrCreate(method, client.BaseAddress, "/api/v1/futures/" + path, BitunixExchange.RateLimiter.PrivateRest, 1, true);
        return client.SendAsync<T>(definition, parameters, ct);
    }
    private static Parameters SymbolParameters(string symbol, string marginAsset)
    {
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        parameters.Add("symbol", symbol);
        parameters.Add("marginCoin", marginAsset);
        return parameters;
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixAccount>> GetAccountAsync(string marginAsset, CancellationToken ct = default)
    {
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        parameters.Add("marginCoin", marginAsset);
        // The live single-account endpoint returns an object; the documentation's array example is incorrect.
        return SendAsync<BitunixAccount>(HttpMethod.Get, "account", parameters, ct);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixLeverageAndMarginMode>> GetLeverageAndMarginModeAsync(string symbol, string marginAsset, CancellationToken ct = default)
        => SendAsync<BitunixLeverageAndMarginMode>(HttpMethod.Get, "account/get_leverage_margin_mode", SymbolParameters(symbol, marginAsset), ct);
    /// <inheritdoc />
    public Task<HttpResult<BitunixLeverage>> SetLeverageAsync(string symbol, string marginAsset, int leverage, CancellationToken ct = default)
    {
        if (leverage < 1)
            throw new ArgumentOutOfRangeException(nameof(leverage));
        var parameters = SymbolParameters(symbol, marginAsset);
        parameters.Add("leverage", leverage);
        // The live mutation returns an object, unlike the array in the official example.
        return SendAsync<BitunixLeverage>(HttpMethod.Post, "account/change_leverage", parameters, ct);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixMarginMode>> SetMarginModeAsync(string symbol, string marginAsset, string marginMode, CancellationToken ct = default)
    {
        if (marginMode is not ("ISOLATION" or "CROSS"))
            throw new ArgumentOutOfRangeException(nameof(marginMode));
        var parameters = SymbolParameters(symbol, marginAsset);
        parameters.Add("marginMode", marginMode);
        // The live mutation returns an object, unlike the array in the official example.
        return SendAsync<BitunixMarginMode>(HttpMethod.Post, "account/change_margin_mode", parameters, ct);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixPositionMode>> SetPositionModeAsync(string positionMode, CancellationToken ct = default)
    {
        if (positionMode is not ("ONE_WAY" or "HEDGE"))
            throw new ArgumentOutOfRangeException(nameof(positionMode));
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        parameters.Add("positionMode", positionMode);
        // The live mutation returns an object, unlike the array in the official example.
        return SendAsync<BitunixPositionMode>(HttpMethod.Post, "account/change_position_mode", parameters, ct);
    }
    #endregion
}
