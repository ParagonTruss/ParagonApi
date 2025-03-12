namespace ParagonApi.Connections;

public class TrussesConnection
{
    private HttpClient Client { get; }

    public TrussesConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    public async Task<Truss> Find(Guid guid)
    {
        var response = await Client.GetAsync($"api/public/trusses/{guid}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return Serialization.Deserialize<Truss>(content);
    }

    public async Task<UploadFilesResult> Upload(BinaryUploadFile file)
    {
        var requestBody = Serialization.Serialize(new List<Base64File> { file.ToBase64File() });
        var requestBodyContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("/api/public/trusses/uploadFiles", requestBodyContent);

        var responseContent = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();

        var uploadFilesResult = Serialization.Deserialize<UploadFilesResult>(responseContent);

        return uploadFilesResult;
    }

    public async Task<Dictionary<Guid, Truss>> FetchTrussesFromAnalysisSets(List<Guid> analysisSetGuids)
    {
        var requestBody = Serialization.Serialize(analysisSetGuids);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("api/public/analysisSets/fetchTrussesFromAnalysisSets", requestContent);

        var responseContent = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();

        var trussResults = Serialization.Deserialize<Dictionary<Guid, Truss>>(responseContent);

        return trussResults;
    }

    public async Task<AnalysisSet> Analyze(Guid guid)
    {
        var response = await Client.PostAsync($"/api/public/trusses/{guid}/analyze", null);

        var responseContent = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();

        return Serialization.Deserialize<AnalysisSet>(responseContent);
    }

    public async Task<AnalysisSet> UpgradeAndAnalyze(Guid guid)
    {
        var response = await Client.PostAsync($"/api/public/trusses/{guid}/upgradeAndAnalyze", null);

        var responseContent = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();

        return Serialization.Deserialize<AnalysisSet>(responseContent);
    }

    public async Task<Truss> CreateProfileTruss(Guid projectGuid, Profile profile)
    {
        var requestBody = Serialization.Serialize(profile);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync($"api/public/projects/{projectGuid}/createProfileTruss", requestContent);

        var responseContent = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();

        return Serialization.Deserialize<Truss>(responseContent);
    }
}
