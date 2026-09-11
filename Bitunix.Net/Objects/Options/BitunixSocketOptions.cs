using CryptoExchange.Net.Objects.Options;
namespace Bitunix.Net.Objects.Options;
/// <summary>Bitunix socket client options.</summary>
public class BitunixSocketOptions : SocketExchangeOptions<BitunixEnvironment, BitunixCredentials>
{
    /// <summary>Defaults applied to new clients.</summary>
    internal static BitunixSocketOptions Default { get; set; } = new() { Environment = BitunixEnvironment.Live, SocketSubscriptionsCombineTarget = 3 };
    /// <summary>Futures API options.</summary>
    public SocketApiOptions FuturesOptions { get; private set; } = new();
    /// <summary>Creates client options.</summary>
    public BitunixSocketOptions() { Default?.Set(this); }
    /// <summary>Copies client and API options.</summary>
    internal BitunixSocketOptions Set(BitunixSocketOptions target)
    {
        target = base.Set<BitunixSocketOptions>(target);
        FuturesOptions.Set(target.FuturesOptions);
        return target;
    }
}
