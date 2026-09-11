using System.Text.Json;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default.Routing;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Sends subscription operations without inventing acknowledgement correlation.</summary>
internal sealed class BitunixQuery : Query<JsonElement>
{
    /// <summary>Creates an operation. Live subscribe returns data without an acknowledgement.</summary>
    internal BitunixQuery(BitunixSocketRequest request) : base(request, false, 1)
    {
        // Unsubscribe only echoes its operation, so it cannot safely correlate concurrent requests either.
        ExpectsResponse = false;
        MessageRouter = MessageRouter.CreateVoid<JsonElement>(request.Operation);
    }
}
