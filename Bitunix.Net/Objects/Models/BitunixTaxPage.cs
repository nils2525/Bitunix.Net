using System.Text.Json.Serialization;

namespace Bitunix.Net.Objects.Models;

/// <summary>Paginated tax export result.</summary>
public class BitunixTaxPage
{
    /// <summary>[<c>records</c>] Tax records in this page.</summary>
    [JsonPropertyName("records")]
    public BitunixTaxRecord[] Records { get; set; } = [];
    /// <summary>[<c>total</c>] Total number of rows.</summary>
    [JsonPropertyName("total")]
    public long Total { get; set; } = 0;
    /// <summary>[<c>current</c>] Current page, starting at one.</summary>
    [JsonPropertyName("current")]
    public int CurrentPage { get; set; } = 0;
    /// <summary>[<c>size</c>] Requested page size.</summary>
    [JsonPropertyName("size")]
    public int PageSize { get; set; } = 0;
    /// <summary>[<c>pages</c>] Total number of pages.</summary>
    [JsonPropertyName("pages")]
    public int TotalPages { get; set; } = 0;
}
