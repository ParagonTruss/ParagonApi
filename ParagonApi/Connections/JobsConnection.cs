namespace ParagonApi.Connections;

public class JobsConnection(HttpClient sealingServiceClient)
{
    private HttpClient Client { get; } = sealingServiceClient;

    public async Task<Job> Find(int jobId)
    {
        var response = await Client.GetAsync($"api/public/jobs/{jobId}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<Job>(content);
    }

    public async Task<List<Job>> Find(DateTime? since = null, string? jobStatus = null)
    {
        var sinceQuery = since == null ? "" : $"since={since:o}";
        var jobStatusQuery = jobStatus == null ? "" : $"jobStatus={jobStatus}";
        var queryString = $"{sinceQuery}{(since != null && jobStatus != null ? "&" : "")}{jobStatusQuery}";
        var response = await Client.GetAsync($"api/public/jobs{(queryString.Length > 0 ? "?" : "")}{queryString}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<Job>>(content);
    }
}
