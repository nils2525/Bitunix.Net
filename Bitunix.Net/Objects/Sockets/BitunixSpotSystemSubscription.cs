using System.Text.Json;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
using Microsoft.Extensions.Logging;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Consumes the public website's informational connected event.</summary>
internal sealed class BitunixSpotSystemSubscription : SystemSubscription
{
    /// <summary>Creates the unauthenticated system subscription.</summary>
    internal BitunixSpotSystemSubscription(ILogger logger) : base(logger, false)
    {
        UserSubscription = false;
        MessageRouter = MessageRouter.CreateVoid<JsonElement>("connected");
    }
}
