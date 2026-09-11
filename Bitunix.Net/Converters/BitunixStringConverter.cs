using System.Text.Json;
using System.Text.Json.Serialization;
namespace Bitunix.Net.Converters;
/// <summary>Accepts the documented numeric and observed string margin-mode representations.</summary>
internal sealed class BitunixStringConverter : JsonConverter<string>
{
    /// <inheritdoc />
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.TokenType == JsonTokenType.String ? reader.GetString() : reader.GetInt32().ToString(System.Globalization.CultureInfo.InvariantCulture);
    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) => writer.WriteStringValue(value);
}
