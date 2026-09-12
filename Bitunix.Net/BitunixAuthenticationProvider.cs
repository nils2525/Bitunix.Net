using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
namespace Bitunix.Net;
/// <summary>Signs Bitunix REST and private socket requests.</summary>
internal sealed partial class BitunixAuthenticationProvider(BitunixCredentials credentials) : AuthenticationProvider<BitunixCredentials>(credentials)
{
    private static readonly IMessageSerializer Serializer = new SystemTextJsonMessageSerializer(BitunixExchange.SerializerContext);

    /// <inheritdoc />
    public override string Key => ApiCredentials.Key;

    /// <summary>Creates the two-stage lowercase SHA256 signature specified by <a href="https://www.bitunix.com/api-docs/futures/common/sign.html" />.</summary>
    internal string Sign(string nonce, string timestamp, string query = "", string body = "")
        => SignSHA256(SignSHA256(nonce + timestamp + Key + query + body).ToLowerInvariant() + ApiCredentials.Secret).ToLowerInvariant();

    /// <inheritdoc />
    public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration requestConfig)
    {
        if (!requestConfig.RequestDefinition.Authenticated)
            return;

        var nonce = Guid.NewGuid().ToString("N");
        var timestamp = GetMillisecondTimestamp(apiClient);
        // The signature concatenates sorted keys and unescaped values without '&' or '=' delimiters.
        var query = requestConfig.QueryParameters == null ? "" : string.Concat(requestConfig.QueryParameters.OrderBy(x => x.Key, StringComparer.Ordinal).Select(x => x.Key + Convert.ToString(x.Value, System.Globalization.CultureInfo.InvariantCulture)));
        var body = requestConfig.ParameterPosition == HttpMethodParameterPosition.InBody ? GetSerializedBody(Serializer, requestConfig.BodyParameters) : "";
        if (requestConfig.ParameterPosition == HttpMethodParameterPosition.InBody)
            requestConfig.SetBodyContent(body);

        requestConfig.Headers ??= new Dictionary<string, string>();
        requestConfig.Headers.Add("api-key", Key);
        requestConfig.Headers.Add("nonce", nonce);
        requestConfig.Headers.Add("timestamp", timestamp);
        requestConfig.Headers.Add("sign", Sign(nonce, timestamp, query, body));
        requestConfig.Headers.Add("language", "en-US");
    }
}
