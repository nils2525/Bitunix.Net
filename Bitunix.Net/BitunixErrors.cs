using CryptoExchange.Net.Objects.Errors;
namespace Bitunix.Net;
/// <summary>Preserves native errors; domain error semantics belong to the consuming application.</summary>
internal static class BitunixErrors
{
    /// <summary>Native error mapping.</summary>
    internal static ErrorMapping Errors { get; } = new([]);
}
