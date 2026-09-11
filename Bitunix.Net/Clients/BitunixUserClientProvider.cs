using Bitunix.Net.Interfaces.Clients;
using Bitunix.Net.Objects.Options;
using CryptoExchange.Net.Clients;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace Bitunix.Net.Clients;
/// <inheritdoc />
public class BitunixUserClientProvider : UserClientProvider<IBitunixRestClient, IBitunixSocketClient, BitunixRestOptions, BitunixSocketOptions, BitunixCredentials, BitunixEnvironment>, IBitunixUserClientProvider
{
    /// <inheritdoc />
    public override string ExchangeName => BitunixExchange.Metadata.Id;
    /// <summary>Creates a configured provider.</summary>
    public BitunixUserClientProvider(HttpClient? httpClient, ILoggerFactory? loggerFactory, IOptions<BitunixRestOptions> restOptions, IOptions<BitunixSocketOptions> socketOptions)
        : base(httpClient, loggerFactory, restOptions, socketOptions) { }
    /// <inheritdoc />
    protected override IBitunixRestClient ConstructRestClient(HttpClient client, ILoggerFactory? loggerFactory, IOptions<BitunixRestOptions> options) => new BitunixRestClient(client, loggerFactory, options);
    /// <inheritdoc />
    protected override IBitunixSocketClient ConstructSocketClient(ILoggerFactory? loggerFactory, IOptions<BitunixSocketOptions> options) => new BitunixSocketClient(options, loggerFactory);
}
