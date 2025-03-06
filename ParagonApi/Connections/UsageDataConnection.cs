namespace ParagonApi.Connections;

public class UsageDataConnection
{
    private HttpClient Client { get; }

    public UsageDataConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    /// <param name="year">Required parameter that specifies the year (int) to include in the query</param>
    /// <param name="month">Optional parameter (1-12) (int) to specify the month in the query</param>
    public async Task<List<UsageDataForOrganization>> GetForOrganization(int year, int? month = null)
    {
        var monthQueryString = month.HasValue ? $"month={month.Value}" : null;
        var queryString = $"?year={year}{(month.HasValue ? "&" : "")}{monthQueryString ?? ""}";
        var url = $"api/public/usageData{queryString}";
        var response = await Client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<UsageDataForOrganization>>(content);
    }

    /// <param name="year">Required parameter that specifies the year (int) to include in the query</param>
    /// <param name="month">Optional parameter (1-12) (int) to specify the month in the query</param>
    public async Task<List<UsageData>> GetAllUsages(int year, int? month = null)
    {
        var yearQueryString = $"year={year}";
        var monthQueryString = month.HasValue ? $"month={month.Value}" : null;
        var queryString = $"?{yearQueryString}{(month.HasValue ? "&" : "")}{monthQueryString ?? ""}";
        var response = await Client.GetAsync($"api/public/usageData/allUsagesRoot{queryString}");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<UsageData>>(content);
    }

    /// <param name="year">Required parameter that specifies the year (int) to include in the query</param>
    /// <param name="month">Optional parameter (1-12) (int) to specify the month in the query</param>
    public async Task<List<UsageDataForOrganization>> GetForAllOrganizations(int year, int? month = null)
    {
        var yearQueryString = $"year={year}";
        var monthQueryString = month.HasValue ? $"month={month.Value}" : null;
        var queryString = $"?{yearQueryString}{(month.HasValue ? "&" : "")}{monthQueryString ?? ""}";
        var response = await Client.GetAsync($"api/public/usageData/forAllOrganizationsRoot{queryString}");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<UsageDataForOrganization>>(content);
    }
}
