namespace ParagonApi;

using System.Diagnostics;

public static class ParagonApiAuthorizer
{
    public static async Task<string> ObtainJwtToken(ParagonApiConfiguration configuration)
    {
        var jwtStorage = new JwtStorage(jwtStorageFileName: configuration.JwtStorageFileName);
        var existingToken = jwtStorage.Fetch();

        if (existingToken != null)
            return existingToken;

        var jwt = await ObtainJwtByUserAuthorization(configuration.Urls).ConfigureAwait(false);

        jwtStorage.Store(jwt);
        return jwt;
    }

    private static async Task<string> ObtainJwtByUserAuthorization(ConnectionUrls connectionUrls)
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = connectionUrls.UserServiceUri;

        var response = await httpClient
            .GetAsync("api/token", HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to obtain authorization token from user service.");
        }

        var contentStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        using var responseReader = new StreamReader(contentStream);
        var authorizationToken =
            await responseReader.ReadLineAsync().ConfigureAwait(false)
            ?? throw new Exception("Authorization token not received.");

        var authorizationUrl = new Uri(
            connectionUrls.ParagonServicesUri,
            $"api/authorize?token={authorizationToken}"
        ).ToString();
        OpenAuthorizationPageInBrowser(authorizationUrl);

        return await responseReader.ReadLineAsync().ConfigureAwait(false) ?? throw new Exception("JWT not received.");
    }

    private static void OpenAuthorizationPageInBrowser(string authorizationUrl)
    {
        var processInfo = new ProcessStartInfo { FileName = authorizationUrl, UseShellExecute = true };
        Process.Start(processInfo);
    }
}
