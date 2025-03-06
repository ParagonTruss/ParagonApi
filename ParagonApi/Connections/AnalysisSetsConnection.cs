namespace ParagonApi.Connections;

public class AnalysisSetsConnection
{
    private HttpClient Client { get; }

    public AnalysisSetsConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    public async Task<AnalysisSet> Get(Guid guid)
    {
        var response = await Client.GetAsync($"api/public/analysisSets/{guid}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return Serialization.Deserialize<AnalysisSet>(content);
    }
}
