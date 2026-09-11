using System.Text.Json;
using System.Text.Json.Serialization;
using Bitunix.Net.Objects.Models;
using Bitunix.Net.Objects.Sockets;
namespace Bitunix.Net.Converters;
/// <summary>JSON metadata for the supported public market data contracts.</summary>
[JsonSerializable(typeof(BitunixResponse<BitunixSpotSymbol[]>))]
[JsonSerializable(typeof(BitunixResponse<BitunixSymbol[]>))]
[JsonSerializable(typeof(BitunixResponse<BitunixTicker[]>))]
[JsonSerializable(typeof(BitunixResponse<BitunixFundingRate[]>))]
[JsonSerializable(typeof(BitunixResponse<BitunixOrderBook>))]
[JsonSerializable(typeof(BitunixSocketEvent<BitunixTickerUpdate[]>))]
[JsonSerializable(typeof(BitunixTickerUpdate))]
[JsonSerializable(typeof(BitunixSocketEvent<BitunixPriceUpdate>))]
[JsonSerializable(typeof(BitunixSocketEvent<BitunixTrade[]>))]
[JsonSerializable(typeof(BitunixSocketEvent))]
[JsonSerializable(typeof(BitunixSocketRequest))]
[JsonSerializable(typeof(BitunixPing))]
[JsonSerializable(typeof(JsonElement))]
internal partial class BitunixSourceGenerationContext : JsonSerializerContext { }
