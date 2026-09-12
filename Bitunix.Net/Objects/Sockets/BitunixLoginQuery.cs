using System.Text.Json;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Awaits the login result before allowing private subscriptions.</summary>
internal sealed class BitunixLoginQuery : Query<JsonElement>
{
    #region Fields
    private readonly SocketApiClient _client;
    #endregion

    #region Constructors
    /// <summary>Creates one connection authentication operation.</summary>
    internal BitunixLoginQuery(SocketApiClient client, BitunixLoginRequest request) : base(request, false, 1)
    {
        _client = client;
        MessageRouter = MessageRouter.CreateForQuery<JsonElement>("login", HandleMessage);
    }
    #endregion

    #region Methods
    private CallResult<JsonElement> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, JsonElement message)
    {
        if (message.TryGetProperty("data", out var data) && data.TryGetProperty("result", out var result) && result.ValueKind == JsonValueKind.True)
            return CallResult<JsonElement>.Ok(message, originalData);
        var error = data.ValueKind == JsonValueKind.Object && data.TryGetProperty("msg", out var msg) ? msg.GetString() : "Bitunix socket authentication failed";
        return CallResult<JsonElement>.Fail(new ServerError(_client.GetErrorInfo("login", error)), originalData);
    }
    #endregion
}
