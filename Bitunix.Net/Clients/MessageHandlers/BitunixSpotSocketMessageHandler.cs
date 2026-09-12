using System.Text.Json;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
namespace Bitunix.Net.Clients.MessageHandlers;
/// <summary>Routes website JSON frames by their event without mistaking one batched item for the whole frame.</summary>
internal sealed class BitunixSpotSocketMessageHandler : JsonSocketMessageHandler
{
    /// <inheritdoc />
    protected override MessageTypeDefinition[] TypeEvaluators { get; } = [new() { Fields = [new PropertyFieldReference("event")], TypeIdentifierCallback = x => x.FieldValue("event")! }];
    /// <inheritdoc />
    public override JsonSerializerOptions Options => BitunixExchange.SerializerContext;
}
