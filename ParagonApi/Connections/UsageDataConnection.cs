namespace ParagonApi.Connections;

public class UsageDataConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<UsageData> GetTrussDesignsUsage() => Client.Get<UsageData>("api/public/usageData/trussDesigns");
}
