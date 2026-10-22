using System.Text.Json.Serialization;

namespace Bitunix.Net.Objects.Models;

/// <summary>A row from the Bitunix tax export, retaining exact decimal strings and absent-value markers.</summary>
public class BitunixTaxRecord
{
    /// <summary>[<c>date</c>] Transaction time in UTC.</summary>
    [JsonPropertyName("date")]
    public string Date { get; set; } = "";
    /// <summary>[<c>labelEn</c>] Transaction label.</summary>
    [JsonPropertyName("labelEn")]
    public string Label { get; set; } = "";
    /// <summary>[<c>account</c>] Source account or wallet.</summary>
    [JsonPropertyName("account")]
    public string Account { get; set; } = "";
    /// <summary>[<c>outgoingAsset</c>] Asset sent, or an em dash when absent.</summary>
    [JsonPropertyName("outgoingAsset")]
    public string OutgoingAsset { get; set; } = "";
    /// <summary>[<c>outgoingAmount</c>] Amount sent, or an em dash when absent.</summary>
    [JsonPropertyName("outgoingAmount")]
    public string OutgoingAmount { get; set; } = "";
    /// <summary>[<c>incomingAsset</c>] Asset received, or an em dash when absent.</summary>
    [JsonPropertyName("incomingAsset")]
    public string IncomingAsset { get; set; } = "";
    /// <summary>[<c>incomingAmount</c>] Amount received, or an em dash when absent.</summary>
    [JsonPropertyName("incomingAmount")]
    public string IncomingAmount { get; set; } = "";
    /// <summary>[<c>feeAsset</c>] Fee asset, or an em dash when absent.</summary>
    [JsonPropertyName("feeAsset")]
    public string FeeAsset { get; set; } = "";
    /// <summary>[<c>feeAmount</c>] Fee amount, or an em dash when absent.</summary>
    [JsonPropertyName("feeAmount")]
    public string FeeAmount { get; set; } = "";
    /// <summary>[<c>typeId</c>] Tax data type code.</summary>
    [JsonPropertyName("typeId")]
    public string TypeId { get; set; } = "";
    /// <summary>[<c>txId</c>] On-chain transaction identifier, or an em dash when absent.</summary>
    [JsonPropertyName("txId")]
    public string TransactionId { get; set; } = "";
    /// <summary>[<c>fromAddress</c>] Sender address, or an em dash when absent.</summary>
    [JsonPropertyName("fromAddress")]
    public string FromAddress { get; set; } = "";
    /// <summary>[<c>toAddress</c>] Recipient address, or an em dash when absent.</summary>
    [JsonPropertyName("toAddress")]
    public string ToAddress { get; set; } = "";
    /// <summary>[<c>network</c>] On-chain network, or an em dash when absent.</summary>
    [JsonPropertyName("network")]
    public string Network { get; set; } = "";
    /// <summary>[<c>referenceId</c>] Identifier shared by related transaction legs.</summary>
    [JsonPropertyName("referenceId")]
    public string ReferenceId { get; set; } = "";
    /// <summary>[<c>comment</c>] Additional transaction context, or an em dash when absent.</summary>
    [JsonPropertyName("comment")]
    public string Comment { get; set; } = "";
}
