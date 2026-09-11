using System.Text.Json;
using Bitunix.Net.Objects.Sockets;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
namespace Bitunix.Net.Clients.MessageHandlers;
/// <summary>Routes channel pushes by channel and symbol, and control messages by operation.</summary>
internal sealed class BitunixSocketMessageHandler : JsonSocketMessageHandler
{
    /// <inheritdoc />
    protected override MessageTypeDefinition[] TypeEvaluators { get; } =
    [
        new() { Fields = [new PropertyFieldReference("ch")], TypeIdentifierCallback = x => x.FieldValue("ch")! },
        new() { Fields = [new PropertyFieldReference("op")], TypeIdentifierCallback = x => x.FieldValue("op")! }
    ];
    /// <inheritdoc />
    public override JsonSerializerOptions Options => BitunixExchange.SerializerContext;
    /// <summary>Configures native topic extraction.</summary>
    internal BitunixSocketMessageHandler() => AddTopicMapping<BitunixSocketEvent>(x => x.Symbol);
}
