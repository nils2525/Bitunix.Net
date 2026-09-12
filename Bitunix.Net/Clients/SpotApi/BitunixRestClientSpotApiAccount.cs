using Bitunix.Net.Interfaces.Clients.SpotApi;
using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net.Clients.SpotApi;
/// <inheritdoc />
internal sealed class BitunixRestClientSpotApiAccount(BitunixRestClientSpotApi client) : IBitunixRestClientSpotApiAccount
{
    #region Statics
    private static readonly RequestDefinitionCache Definitions = new();
    #endregion

    #region Methods
    private Task<HttpResult<T>> SendAsync<T>(HttpMethod method, string path, Parameters parameters, CancellationToken ct)
    {
        var definition = Definitions.GetOrCreate(method, client.BaseAddress, "/api/spot/v1/" + path, BitunixExchange.RateLimiter.SpotRest, 1, true);
        return client.SendAsync<T>(definition, parameters, ct);
    }
    /// <inheritdoc />
    public Task<HttpResult<BitunixSpotBalance[]>> GetBalancesAsync(CancellationToken ct = default)
        => SendAsync<BitunixSpotBalance[]>(HttpMethod.Get, "user/account", new Parameters(BitunixExchange.ParameterSettings), ct);
    /// <inheritdoc />
    public Task<HttpResult<BitunixSpotUser>> GetUserInfoAsync(CancellationToken ct = default)
        => SendAsync<BitunixSpotUser>(HttpMethod.Get, "user/info", new Parameters(BitunixExchange.ParameterSettings), ct);
    /// <inheritdoc />
    public Task<HttpResult<string>> TransferAsync(string asset, string transferType, decimal amount, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(asset);
        if (transferType is not ("spot_futures" or "futures_spot"))
            throw new ArgumentOutOfRangeException(nameof(transferType));
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount));
        var parameters = new Parameters(BitunixExchange.ParameterSettings);
        parameters.Add("type", transferType);
        parameters.Add("coin", asset);
        parameters.Add("amount", amount, DecimalSerialization.Number);
        return SendAsync<string>(HttpMethod.Post, "funds_transfer", parameters, ct);
    }
    #endregion
}
