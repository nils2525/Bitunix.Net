using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
namespace Bitunix.Net.Objects.Models;
/// <summary>A futures order-book price and base-asset quantity pair.</summary>
[JsonConverter(typeof(ArrayConverter<BitunixOrderBookEntry>))]
public class BitunixOrderBookEntry : ISymbolOrderBookEntry
{
    /// <summary>[<c>0</c>] Price of the level.</summary>
    [ArrayProperty(0)]
    public decimal Price { get; set; }
    /// <summary>[<c>1</c>] Base-asset quantity at this price.</summary>
    [ArrayProperty(1)]
    public decimal Quantity { get; set; }
}
