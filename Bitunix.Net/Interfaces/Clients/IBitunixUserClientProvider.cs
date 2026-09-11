namespace Bitunix.Net.Interfaces.Clients;
/// <summary>Provides configured per-user clients; implemented endpoints remain public.</summary>
public interface IBitunixUserClientProvider
{
    /// <summary>Initializes a user's client configuration.</summary>
    void InitializeUserClient(string userIdentifier, BitunixCredentials credentials, BitunixEnvironment? environment = null);
    /// <summary>Clears one user's clients.</summary>
    void ClearUserClients(string userIdentifier);
    /// <summary>Gets a configured REST client.</summary>
    IBitunixRestClient GetRestClient(string userIdentifier, BitunixCredentials? credentials = null, BitunixEnvironment? environment = null);
    /// <summary>Gets a configured WebSocket client.</summary>
    IBitunixSocketClient GetSocketClient(string userIdentifier, BitunixCredentials? credentials = null, BitunixEnvironment? environment = null);
}
