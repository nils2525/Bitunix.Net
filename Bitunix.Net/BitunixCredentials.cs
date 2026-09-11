using CryptoExchange.Net.Authentication;
namespace Bitunix.Net;
/// <summary>Bitunix key and secret configuration. Private endpoints are not implemented.</summary>
public class BitunixCredentials : HMACCredential
{
    /// <summary>Creates credentials for configuration binding.</summary>
    public BitunixCredentials() { }
    /// <summary>Creates credentials from a key and secret.</summary>
    public BitunixCredentials(string key, string secret) : base(key, secret) { }
    /// <summary>Copies credentials.</summary>
    public BitunixCredentials(HMACCredential credential) : base(credential.Key, credential.Secret) { }
    /// <inheritdoc />
    public override ApiCredentials Copy() => new BitunixCredentials(this);
}
