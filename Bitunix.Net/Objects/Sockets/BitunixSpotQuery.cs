using System.Text.Json;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default.Routing;
namespace Bitunix.Net.Objects.Sockets;
/// <summary>Sends website operations whose replies have no request identifier.</summary>
internal sealed class BitunixSpotQuery : Query<JsonElement>
{
    /// <summary>Creates an operation without treating an unrelated channel snapshot as an acknowledgement.</summary>
    internal BitunixSpotQuery(BitunixSpotSocketRequest request) : base(request, false, 1)
    {
        ExpectsResponse = false;
        // Send-only queries are still registered while awaiting the send/rate-limit queue.
        // They must have no receive routes: a concurrent snapshot belongs exclusively to subscriptions.
        MessageRouter = MessageRouter.Create();
    }
}
