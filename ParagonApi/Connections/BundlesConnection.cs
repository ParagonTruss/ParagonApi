namespace ParagonApi.Connections;

public class BundlesConnection
{
    private HttpClient Client { get; }

    public BundlesConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    public async Task<Bundle> Find(Guid guid)
    {
        var response = await Client.GetAsync($"api/public/bundles/{guid}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<Bundle>(content);
    }

    public async Task<List<Bundle>> FindForProductionGroup(Guid productionGroupGuid)
    {
        var response = await Client.GetAsync($"api/public/bundles/forProductionGroup/{productionGroupGuid}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<Bundle>>(content);
    }

    public async Task<Bundle> Insert(Bundle bundle)
    {
        var requestBody = Serialization.Serialize(bundle);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("api/public/bundles", requestContent);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<Bundle>(content);
    }

    public async Task Delete(Guid bundleGuid)
    {
        var response = await Client.DeleteAsync($"api/public/bundles/{bundleGuid}");
        response.EnsureSuccessStatusCode();
    }

    public async Task FinishComponentsForBundles(List<Guid> bundleGuids)
    {
        var requestBody = Serialization.Serialize(bundleGuids);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("api/public/bundles/finishComponentsForBundles", requestContent);
        response.EnsureSuccessStatusCode();
    }
}
