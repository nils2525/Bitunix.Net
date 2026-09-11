using System.Text.Json;
using System.Text.Json.Serialization;
using Bitunix.Net.Objects.Models;
namespace Bitunix.Net.Converters;
/// <summary>Handles both the documented ticker array and the observed per-symbol object.</summary>
internal sealed class BitunixTickerUpdatesConverter : JsonConverter<BitunixTickerUpdate[]>
{
    /// <inheritdoc />
    public override BitunixTickerUpdate[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartObject)
            return [JsonSerializer.Deserialize<BitunixTickerUpdate>(ref reader, options) ?? throw new JsonException("Missing ticker.")];
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException("Expected a Bitunix ticker object or array.");
        var result = new List<BitunixTickerUpdate>();
        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            result.Add(JsonSerializer.Deserialize<BitunixTickerUpdate>(ref reader, options) ?? throw new JsonException("Missing ticker."));
        return result.ToArray();
    }
    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, BitunixTickerUpdate[] value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var item in value) JsonSerializer.Serialize(writer, item, options);
        writer.WriteEndArray();
    }
}
