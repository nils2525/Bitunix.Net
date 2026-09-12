using Bitunix.Net;
using Bitunix.Net.Clients;
using Bitunix.Net.Interfaces.Clients;
using Bitunix.Net.Objects.Options;
using CryptoExchange.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace Microsoft.Extensions.DependencyInjection;
/// <summary>Bitunix dependency injection registration.</summary>
public static class ServiceCollectionExtensions
{
    /// <summary>Adds futures clients and their configured user-client provider.</summary>
    public static IServiceCollection AddBitunix(this IServiceCollection services, Action<BitunixOptions>? configure = null)
    {
        var options = new BitunixOptions();
        options.Rest.Environment = null!;
        options.Socket.Environment = null!;
        configure?.Invoke(options);
        options.Rest.Environment ??= options.Environment ?? BitunixEnvironment.Live;
        options.Socket.Environment ??= options.Environment ?? BitunixEnvironment.Live;
        options.Rest.ApiCredentials ??= options.ApiCredentials;
        options.Socket.ApiCredentials ??= options.ApiCredentials;
        services.AddSingleton(Options.Options.Create(options.Rest));
        services.AddSingleton(Options.Options.Create(options.Socket));
        services.AddHttpClient<IBitunixRestClient, BitunixRestClient>((client, provider) =>
        {
            client.Timeout = options.Rest.RequestTimeout;
            return new BitunixRestClient(client, provider.GetRequiredService<ILoggerFactory>(), provider.GetRequiredService<IOptions<BitunixRestOptions>>());
        }).ConfigurePrimaryHttpMessageHandler(() => LibraryHelpers.CreateHttpClientMessageHandler(options.Rest)).SetHandlerLifetime(Timeout.InfiniteTimeSpan);
        services.Add(new ServiceDescriptor(typeof(IBitunixSocketClient), provider => new BitunixSocketClient(provider.GetRequiredService<IOptions<BitunixSocketOptions>>(), provider.GetRequiredService<ILoggerFactory>()), options.SocketClientLifeTime ?? ServiceLifetime.Singleton));
        services.AddSingleton<IBitunixUserClientProvider>(provider => new BitunixUserClientProvider(
            provider.GetRequiredService<IHttpClientFactory>().CreateClient(typeof(IBitunixRestClient).Name),
            provider.GetRequiredService<ILoggerFactory>(), provider.GetRequiredService<IOptions<BitunixRestOptions>>(), provider.GetRequiredService<IOptions<BitunixSocketOptions>>()));
        return services;
    }
}
