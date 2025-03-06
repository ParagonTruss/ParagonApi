namespace ParagonApi.Connections;

public class ProductionGroupsConnection
{
    private HttpClient Client { get; }

    public ProductionGroupsConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    public async Task<ProductionGroup> Find(Guid guid)
    {
        var response = await Client.GetAsync($"api/public/productionGroups/{guid}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<ProductionGroup>(content);
    }

    public async Task<List<ProductionGroup>> FindForProject(Guid projectGuid)
    {
        var response = await Client.GetAsync($"api/public/productionGroups/forProject/{projectGuid}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<ProductionGroup>>(content);
    }

    public async Task Insert(ProductionGroup productionGroup)
    {
        var requestBody = Serialization.Serialize(productionGroup);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("api/public/productionGroups", requestContent);
        response.EnsureSuccessStatusCode();
    }
}
