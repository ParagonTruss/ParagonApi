namespace ParagonApi;

public class ParagonApiConfiguration
{
    /// <summary>
    /// A token will be obtained if this field is left null -- only set it if you need control over authentication.
    /// </summary>
    public string? JwtToken { get; set; } = null;

    /// <summary>
    /// The URLs that will be used for connections. Defaults to Paragon's production URLs, but can be overriden for
    /// testing in other environments.
    /// </summary>
    public ConnectionUrls Urls { get; set; } = ConnectionUrls.Default;

    /// <summary>
    /// The name of the file where the JWT will be stored. Can be overriden for testing in environments where JWTs may
    /// differ.
    /// </summary>
    public string JwtStorageFileName { get; set; } = "jwt-production.txt";
}
