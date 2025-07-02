namespace ParagonApi.Connections;

public class ProjectsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<List<Project>> Get() => Client.Get<List<Project>>("api/public/projects");

    public Task<Project> Get(Guid guid) => Client.Get<Project>($"api/public/projects/{guid}");

    public Task<Project> Create(NewProject project) => Client.Post<NewProject, Project>("api/public/projects", project);

    public Task<UploadFilesResult> UploadFiles(Guid projectGuid, List<BinaryUploadFile> files) =>
        Client.Post<List<Base64File>, UploadFilesResult>(
            $"/api/public/projects/{projectGuid}/uploadFiles",
            files.Select(file => file.ToBase64File()).ToList()
        );

    public Task<LoadSettings> GetLoadSettings(Guid projectGuid) =>
        Client.Get<LoadSettings>($"api/public/projects/{projectGuid}/loadSettings");

    public Task<LoadSettings> UpdateLoadSettings(Guid projectGuid, LoadSettings loadSettings) =>
        Client.Put<LoadSettings, LoadSettings>($"api/public/projects/{projectGuid}/loadSettings", loadSettings);
}
