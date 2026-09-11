using System.Text.Json;
using Bitunix.Net.Converters;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
namespace Bitunix.Net;
/// <summary>Bitunix metadata and protocol configuration.</summary>
public static class BitunixExchange
{
    /// <summary>Source-generated JSON serializer configuration.</summary>
    internal static JsonSerializerOptions SerializerContext { get; } = SerializerOptions.WithConverters(JsonSerializerContextCache.GetOrCreate<BitunixSourceGenerationContext>(), new BitunixTickerUpdatesConverter());
    /// <summary>Request parameter serialization.</summary>
    internal static ParameterSerializationSettings ParameterSettings { get; } = new();
    /// <summary>Exchange rate limits.</summary>
    public static BitunixRateLimiters RateLimiter { get; } = new();
    /// <summary>Exchange metadata.</summary>
    public static PlatformInfo Metadata { get; } = new("Bitunix", "Bitunix", "", "https://www.bitunix.com", ["https://www.bitunix.com/api-docs/"], PlatformType.CryptoCurrencyExchange, CentralizationType.Centralized, BitunixEnvironment.All);
    /// <summary>Formats a native spot or linear perpetual symbol.</summary>
    public static string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
        => tradingMode == TradingMode.Spot ? (baseAsset + quoteAsset).ToLowerInvariant() : (baseAsset + quoteAsset).ToUpperInvariant();
}
