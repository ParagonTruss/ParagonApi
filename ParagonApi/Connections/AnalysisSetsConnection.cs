namespace ParagonApi.Connections;

public class AnalysisSetsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<AnalysisSet> Get(Guid guid) => Client.Get<AnalysisSet>($"api/public/analysisSets/{guid}");
}
