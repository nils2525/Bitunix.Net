using CryptoExchange.Net.Objects.Options;
namespace Bitunix.Net.Objects.Options;
/// <summary>Bitunix rest client options.</summary>
public class BitunixRestOptions : RestExchangeOptions<BitunixEnvironment, BitunixCredentials>
{
    /// <summary>Defaults applied to new clients.</summary>
    internal static BitunixRestOptions Default { get; set; } = new() { Environment = BitunixEnvironment.Live, AutoTimestamp = false };
    /// <summary>Futures API options.</summary>
    public RestApiOptions FuturesOptions { get; private set; } = new();
    /// <summary>Spot API options.</summary>
    public RestApiOptions SpotOptions { get; private set; } = new();
    /// <summary>Creates client options.</summary>
    public BitunixRestOptions() { Default?.Set(this); }
    /// <summary>Copies client and API options.</summary>
    internal BitunixRestOptions Set(BitunixRestOptions target)
    {
        target = base.Set<BitunixRestOptions>(target);
        FuturesOptions.Set(target.FuturesOptions);
        SpotOptions.Set(target.SpotOptions);
        return target;
    }
}
