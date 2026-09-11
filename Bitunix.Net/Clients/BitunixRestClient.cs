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
/// <inheritdoc cref="IBitunixRestClient" />
public class BitunixRestClient : BaseRestClient<BitunixEnvironment, BitunixCredentials>, IBitunixRestClient
{
    /// <inheritdoc />
    public IBitunixRestClientFuturesApi FuturesApi { get; }
    /// <inheritdoc />
    public IBitunixRestClientSpotApi SpotApi { get; }
    /// <summary>Creates a public REST client.</summary>
    public BitunixRestClient(Action<BitunixRestOptions>? optionsDelegate = null) : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate))) { }
    /// <summary>Creates a client with an injected transport and options.</summary>
    public BitunixRestClient(HttpClient? httpClient, ILoggerFactory? loggerFactory, IOptions<BitunixRestOptions> options) : base(loggerFactory, "Bitunix")
    {
        Initialize(options.Value);
        FuturesApi = AddApiClient(new BitunixRestClientFuturesApi(loggerFactory, httpClient, options.Value));
        SpotApi = AddApiClient(new BitunixRestClientSpotApi(loggerFactory, httpClient, options.Value));
    }
}
