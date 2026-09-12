using Bitunix.Net.Clients.MessageHandlers;
using Bitunix.Net.Interfaces.Clients.SpotApi;
using Bitunix.Net.Objects.Models;
using Bitunix.Net.Objects.Options;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;
namespace Bitunix.Net.Clients.SpotApi;
/// <inheritdoc />
internal sealed class BitunixRestClientSpotApi : RestApiClient<BitunixEnvironment, BitunixAuthenticationProvider, BitunixCredentials>, IBitunixRestClientSpotApi
{
    #region Properties
    /// <inheritdoc />
    protected override ErrorMapping ErrorMapping => BitunixErrors.Errors;
    /// <inheritdoc />
    protected override IRestMessageHandler MessageHandler { get; } = new BitunixRestMessageHandler();
    /// <inheritdoc />
    public IBitunixRestClientSpotApiExchangeData ExchangeData { get; }
    /// <inheritdoc />
    public IBitunixRestClientSpotApiAccount Account { get; }
    #endregion

    #region Constructors
    /// <summary>Creates the spot REST API.</summary>
    internal BitunixRestClientSpotApi(ILoggerFactory? loggerFactory, HttpClient? httpClient, BitunixRestOptions options)
        : base(loggerFactory, BitunixExchange.Metadata.Id, httpClient, options.Environment.SpotRestClientAddress, options, options.SpotOptions)
    {
        ExchangeData = new BitunixRestClientSpotApiExchangeData(this);
        Account = new BitunixRestClientSpotApiAccount(this);
    }
    #endregion

    #region Methods
    /// <inheritdoc />
    protected override IMessageSerializer CreateSerializer() => new SystemTextJsonMessageSerializer(BitunixExchange.SerializerContext);
    /// <inheritdoc />
    protected override BitunixAuthenticationProvider CreateAuthenticationProvider(BitunixCredentials credentials) => new(credentials);
    /// <summary>Sends a request and unwraps its response.</summary>
    internal async Task<HttpResult<T>> SendAsync<T>(RequestDefinition definition, Parameters parameters, CancellationToken ct)
    {
        var result = await base.SendAsync<BitunixResponse<T>>(definition, parameters, ct).ConfigureAwait(false);
        return result.Success ? HttpResult.Ok(result, result.Data.Data) : HttpResult.Fail<T>(result);
    }
    /// <inheritdoc />
    public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverDate = null) => BitunixExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverDate);
    #endregion
}
