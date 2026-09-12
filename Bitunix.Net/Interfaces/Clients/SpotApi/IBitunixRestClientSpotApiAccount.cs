using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net.Interfaces.Clients.SpotApi;
/// <summary>Bitunix spot account and internal wallet transfer requests.</summary>
public interface IBitunixRestClientSpotApiAccount
{
    /// <summary>Gets spot balances. <a href="https://www.bitunix.com/api-docs/spots/en_us/user/#1-checking-account-balance" /></summary>
    Task<HttpResult<BitunixSpotBalance[]>> GetBalancesAsync(CancellationToken ct = default);
    /// <summary>Gets the master user ID associated with the API key; the ID can be null. <a href="https://www.bitunix.com/api-docs/spots/en_us/user/#2-get-user-information" /></summary>
    Task<HttpResult<BitunixSpotUser>> GetUserInfoAsync(CancellationToken ct = default);
    /// <summary>Transfers an asset between this user's spot and futures wallets and returns the transfer ID. Transfer type must be spot_futures or futures_spot. <a href="https://www.bitunix.com/api-docs/spots/en_us/user/#8-transfer" /></summary>
    Task<HttpResult<string>> TransferAsync(string asset, string transferType, decimal amount, CancellationToken ct = default);
}
