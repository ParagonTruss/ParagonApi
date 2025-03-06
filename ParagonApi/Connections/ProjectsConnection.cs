namespace ParagonApi.Connections;

public class ProjectsConnection
{
    private HttpClient Client { get; }

    public ProjectsConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    public async Task<Project> Create(NewProject project)
    {
        var requestBody = Serialization.Serialize(project);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("api/public/projects", requestContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<Project>(responseContent);
    }

    public async Task<UploadFilesResult> UploadFiles(Guid projectGuid, List<BinaryUploadFile> files)
    {
        var requestBody = Serialization.Serialize(files.Select(file => file.ToBase64File()).ToList());
        var requestBodyContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync($"/api/public/projects/{projectGuid}/uploadFiles", requestBodyContent);

        var responseContent = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();

        var uploadFilesResult = Serialization.Deserialize<UploadFilesResult>(responseContent);

        return uploadFilesResult;
    }

    public async Task<LoadSettings> GetLoadSettings(Guid projectGuid)
    {
        var response = await Client.GetAsync($"api/public/projects/{projectGuid}/loadSettings");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<LoadSettings>(responseContent);
    }

    public async Task<LoadSettings> UpdateLoadSettings(Guid projectGuid, LoadSettings loadSettings)
    {
        var requestBody = Serialization.Serialize(loadSettings);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PutAsync($"api/public/projects/{projectGuid}/loadSettings", requestContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<LoadSettings>(responseContent);
    }
}
