using Bitunix.Net.Clients.FuturesApi;
using Bitunix.Net.Clients.SpotApi;
using Bitunix.Net.Interfaces.Clients;
using Bitunix.Net.Interfaces.Clients.FuturesApi;
using Bitunix.Net.Interfaces.Clients.SpotApi;
using Bitunix.Net.Objects.Options;
using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace Bitunix.Net.Clients;
/// <inheritdoc cref="IBitunixSocketClient" />
public class BitunixSocketClient : BaseSocketClient<BitunixEnvironment, BitunixCredentials>, IBitunixSocketClient
{
    /// <inheritdoc />
    public IBitunixSocketClientFuturesApi FuturesApi { get; }
    /// <inheritdoc />
    public IBitunixSocketClientSpotApi SpotApi { get; }
    /// <summary>Creates a futures market and account socket client.</summary>
    public BitunixSocketClient(Action<BitunixSocketOptions>? optionsDelegate = null) : this(Options.Create(ApplyOptionsDelegate(optionsDelegate))) { }
    /// <summary>Creates a socket client using injected options.</summary>
    public BitunixSocketClient(IOptions<BitunixSocketOptions> options, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Bitunix")
    {
        Initialize(options.Value);
        FuturesApi = AddApiClient(new BitunixSocketClientFuturesApi(loggerFactory, options.Value));
        SpotApi = AddApiClient(new BitunixSocketClientSpotApi(loggerFactory, options.Value));
    }
}
