using System.Text.Json;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default.Routing;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Native heartbeat with timeout detection.</summary>
internal sealed class BitunixPingQuery : Query<JsonElement>
{
    /// <summary>Creates a heartbeat which consumes the venue's message budget.</summary>
    internal BitunixPingQuery() : base(new BitunixPing(), false, 1)
    {
        RequestTimeout = TimeSpan.FromSeconds(5);
        MessageRouter = MessageRouter.CreateVoid<JsonElement>("ping");
    }
}
