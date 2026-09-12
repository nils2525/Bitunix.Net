using System.Text.Json;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default.Routing;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Public website heartbeat, using Unix seconds.</summary>
internal sealed class BitunixSpotPingQuery : Query<JsonElement>
{
    /// <summary>Creates a ping which waits for the native pong response.</summary>
    internal BitunixSpotPingQuery() : base(new BitunixSpotSocketRequest { Event = "ping", Ping = DateTimeOffset.UtcNow.ToUnixTimeSeconds() }, false, 1)
    {
        RequestTimeout = TimeSpan.FromSeconds(5);
        MessageRouter = MessageRouter.CreateVoid<JsonElement>("pong");
    }
}
