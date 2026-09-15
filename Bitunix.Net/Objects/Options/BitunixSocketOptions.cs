using CryptoExchange.Net.Objects.Options;
namespace Bitunix.Net.Objects.Options;
/// <summary>Bitunix socket client options.</summary>
public class BitunixSocketOptions : SocketExchangeOptions<BitunixEnvironment, BitunixCredentials>
{
    /// <summary>Defaults applied to new clients.</summary>
    internal static BitunixSocketOptions Default { get; set; } = new()
    {
        Environment = BitunixEnvironment.Live,
        // Small incremental requests should share sockets up to the channel cap, just like large batches.
        SocketSubscriptionsCombineTarget = 300,
        SocketIndividualSubscriptionCombineTarget = 300,
        ConnectDelayAfterRateLimited = TimeSpan.FromSeconds(30)
    };
    /// <summary>Futures API options.</summary>
    public SocketApiOptions FuturesOptions { get; private set; } = new();
    /// <summary>Public spot website API options.</summary>
    public SocketApiOptions SpotOptions { get; private set; } = new();
    /// <summary>Creates client options.</summary>
    public BitunixSocketOptions() { Default?.Set(this); }
    /// <summary>Copies client and API options.</summary>
    internal BitunixSocketOptions Set(BitunixSocketOptions target)
    {
        target = base.Set<BitunixSocketOptions>(target);
        // CEN 12.5.1 does not copy these connection safeguards in SocketExchangeOptions.Set.
        target.SocketIndividualSubscriptionCombineTarget = SocketIndividualSubscriptionCombineTarget;
        target.ConnectDelayAfterRateLimited = ConnectDelayAfterRateLimited;
        FuturesOptions.Set(target.FuturesOptions);
        SpotOptions.Set(target.SpotOptions);
        return target;
    }
}
