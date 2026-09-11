using System.Text.Json;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
using Microsoft.Extensions.Logging;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Consumes informational connection and uncorrelated unsubscribe messages.</summary>
internal sealed class BitunixSystemSubscription : SystemSubscription
{
    /// <summary>Creates the public control-message handler.</summary>
    internal BitunixSystemSubscription(ILogger logger) : base(logger, false)
    {
        UserSubscription = false;
        MessageRouter = MessageRouter.Create(
            MessageRoute.CreateForEvent<JsonElement>("connect", HandleMessage),
            MessageRoute.CreateForEvent<JsonElement>("unsubscribe", HandleMessage));
    }
    private CallResult HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, JsonElement message) => CallResult.Ok();
}
