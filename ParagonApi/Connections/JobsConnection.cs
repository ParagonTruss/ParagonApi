namespace ParagonApi.Connections;

public class JobsConnection(HttpClient sealingServiceClient)
{
    private HttpClient Client { get; } = sealingServiceClient;

    public Task<Job> Find(int jobId) => Client.Get<Job>($"api/public/jobs/{jobId}");

    public Task<List<Job>> Find(DateTime? since = null, string? jobStatus = null)
    {
        var sinceQuery = since == null ? "" : $"since={since:o}";
        var jobStatusQuery = jobStatus == null ? "" : $"jobStatus={jobStatus}";
        var queryString = $"{sinceQuery}{(since != null && jobStatus != null ? "&" : "")}{jobStatusQuery}";
        return Client.Get<List<Job>>($"api/public/jobs{(queryString.Length > 0 ? "?" : "")}{queryString}");
    }
}
