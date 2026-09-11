using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net;
/// <summary>Guards the public-only client against accidental authenticated requests.</summary>
internal sealed class BitunixAuthenticationProvider(BitunixCredentials credentials) : AuthenticationProvider<BitunixCredentials>(credentials)
{
    /// <inheritdoc />
    public override string Key => ApiCredentials.Key;
    /// <inheritdoc />
    public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration requestConfig)
        => throw new NotSupportedException("Bitunix.Net currently implements public endpoints only.");
}
