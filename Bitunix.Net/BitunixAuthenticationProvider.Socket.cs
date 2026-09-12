using System.Globalization;
using Bitunix.Net.Objects.Sockets;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
namespace Bitunix.Net;
internal sealed partial class BitunixAuthenticationProvider
{
    /// <inheritdoc />
    public override Query? GetAuthenticationQuery(SocketApiClient apiClient, SocketConnection connection, Dictionary<string, object?>? context = null)
    {
        // Regenerate both values on every authentication, including reconnects.
        var timestamp = new DateTimeOffset(GetTimestamp(apiClient)).ToUnixTimeSeconds();
        var nonce = Guid.NewGuid().ToString("N");
        return new BitunixLoginQuery(apiClient, new BitunixLoginRequest
        {
            Arguments = [new BitunixLoginArgument { ApiKey = Key, Timestamp = timestamp, Nonce = nonce, Signature = Sign(nonce, timestamp.ToString(CultureInfo.InvariantCulture)) }]
        });
    }
}
