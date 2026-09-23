using System.Text.Json;
using Bitunix.Net.Objects.Models;
using Bitunix.Net.Objects.Sockets;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using Microsoft.Extensions.Logging;
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
    internal BitunixSocketMessageHandler(ILogger logger)
    {
        AddTopicMapping<BitunixSocketEvent>(x => x.Symbol);
        AddTopicMapping<BitunixSocketEvent<BitunixTickerUpdate[]>>(message =>
        {
            if (message.Data is not { Length: > 0 })
                return null;

            // Live ticker frames have one symbol and can omit the envelope symbol. Never route a
            // future multi-symbol frame using its first item, which would silently lose other symbols.
            var symbol = message.Data[0].Symbol;
            for (var i = 1; i < message.Data.Length; i++)
                if (!string.Equals(symbol, message.Data[i].Symbol, StringComparison.Ordinal))
                {
                    logger.LogError("Ignoring unsupported multi-symbol Bitunix ticker event containing {FirstSymbol} and {OtherSymbol} ({TickerCount} items)", symbol, message.Data[i].Symbol, message.Data.Length);
                    return null;
                }

            return symbol;
        });
    }
}
