using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net.Interfaces.Clients.FuturesApi;
/// <summary>Bitunix futures account requests.</summary>
public interface IBitunixRestClientFuturesApiAccount
{
    /// <summary>Gets futures balances for the specified settlement asset. <a href="https://www.bitunix.com/api-docs/futures/account/get_single_account.html" /></summary>
    Task<HttpResult<BitunixAccount>> GetAccountAsync(string marginAsset, CancellationToken ct = default);
    /// <summary>Gets the symbol leverage and margin mode. <a href="https://www.bitunix.com/api-docs/futures/account/get_leverage_and_margin_mode.html" /></summary>
    Task<HttpResult<BitunixLeverageAndMarginMode>> GetLeverageAndMarginModeAsync(string symbol, string marginAsset, CancellationToken ct = default);
    /// <summary>Changes the symbol leverage. <a href="https://www.bitunix.com/api-docs/futures/account/change_leverage.html" /></summary>
    Task<HttpResult<BitunixLeverage>> SetLeverageAsync(string symbol, string marginAsset, int leverage, CancellationToken ct = default);
    /// <summary>Changes symbol margin mode; open orders or positions can prevent this. <a href="https://www.bitunix.com/api-docs/futures/account/change_margin_mode.html" /></summary>
    Task<HttpResult<BitunixMarginMode>> SetMarginModeAsync(string symbol, string marginAsset, string marginMode, CancellationToken ct = default);
    /// <summary>Changes position mode for the entire futures account; open orders or positions can prevent this. <a href="https://www.bitunix.com/api-docs/futures/account/change_position_mode.html" /></summary>
    Task<HttpResult<BitunixPositionMode>> SetPositionModeAsync(string positionMode, CancellationToken ct = default);
}
