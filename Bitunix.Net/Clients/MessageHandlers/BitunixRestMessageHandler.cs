using System.Net.Http.Headers;
using System.Text.Json;
using Bitunix.Net.Objects.Models;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
namespace Bitunix.Net.Clients.MessageHandlers;
/// <summary>Reads Bitunix native errors, including HTTP-success error envelopes.</summary>
internal sealed class BitunixRestMessageHandler : JsonRestMessageHandler
{
    /// <inheritdoc />
    public override JsonSerializerOptions Options => BitunixExchange.SerializerContext;
    /// <inheritdoc />
    public override async ValueTask<Error> ParseErrorResponse(int httpStatusCode, HttpResponseHeaders responseHeaders, Stream responseStream)
    {
        var (error, document) = await GetJsonDocument(responseStream).ConfigureAwait(false);
        if (error != null) return error;
        using (document)
        {
            var root = document!.RootElement;
            var code = root.TryGetProperty("code", out var codeToken) ? codeToken.ToString() : httpStatusCode.ToString();
            var message = root.TryGetProperty("msg", out var messageToken) ? messageToken.GetString() : null;
            return new ServerError(code, BitunixErrors.Errors.GetErrorInfo(code, message));
        }
    }
    /// <inheritdoc />
    public override Error? CheckDeserializedResponse<T>(HttpResponseHeaders responseHeaders, T result)
    {
        if (result is not BitunixResponse response) return base.CheckDeserializedResponse(responseHeaders, result);
        return response.Code == 0 ? null : new ServerError(response.Code, BitunixErrors.Errors.GetErrorInfo(response.Code.ToString(), response.Message));
    }
}
