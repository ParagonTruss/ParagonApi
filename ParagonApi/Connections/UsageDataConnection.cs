namespace ParagonApi.Connections;

public class UsageDataConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public async Task<UsageData> GetTrussDesignsUsage()
    {
        var response = await Client.GetAsync("api/public/usageData/trussDesigns");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<UsageData>(content);
    }
}
