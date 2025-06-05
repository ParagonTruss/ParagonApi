namespace ParagonApi.Connections;

public class TrussesConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<Truss> Find(Guid guid) => Client.Get<Truss>($"api/public/trusses/{guid}");

    public Task<Dictionary<Guid, string>> GetNames(List<Guid> guids) =>
        Client.Post<List<Guid>, Dictionary<Guid, string>>("api/public/trusses/names", guids);

    public Task<UploadFilesResult> Upload(BinaryUploadFile file) =>
        Client.Post<List<Base64File>, UploadFilesResult>("/api/public/trusses/uploadFiles", [file.ToBase64File()]);

    public Task<Dictionary<Guid, Truss>> FetchTrussesFromAnalysisSets(List<Guid> analysisSetGuids) =>
        Client.Post<List<Guid>, Dictionary<Guid, Truss>>(
            "api/public/analysisSets/fetchTrussesFromAnalysisSets",
            analysisSetGuids
        );

    public Task<AnalysisSet> Analyze(Guid guid) =>
        Client.PostNoContent<AnalysisSet>($"/api/public/trusses/{guid}/analyze");

    public Task<AnalysisSet> UpgradeAndAnalyze(Guid guid) =>
        Client.PostNoContent<AnalysisSet>($"/api/public/trusses/{guid}/upgradeAndAnalyze");

    public Task<Truss> CreateProfileTruss(Guid projectGuid, Profile profile) =>
        Client.Post<Profile, Truss>($"api/public/projects/{projectGuid}/createProfileTruss", profile);
}
