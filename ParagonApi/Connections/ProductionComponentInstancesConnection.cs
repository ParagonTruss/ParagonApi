namespace ParagonApi.Connections;

public class ProductionComponentInstancesConnection
{
    private HttpClient Client { get; }

    public ProductionComponentInstancesConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    public async Task<ProductionComponentInstance> Find(Guid guid)
    {
        var response = await Client.GetAsync($"api/public/productionComponentInstances/{guid}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<ProductionComponentInstance>(content);
    }

    public async Task<List<ProductionComponentInstance>> FindForProductionGroup(Guid productionGroupGuid)
    {
        var response = await Client.GetAsync(
            $"api/public/productionComponentInstances/forProductionGroup/{productionGroupGuid}"
        );
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<ProductionComponentInstance>>(content);
    }

    public async Task<Bundle> BulkInsert(List<ProductionComponentInstance> productionComponentInstances)
    {
        var requestBody = Serialization.Serialize(productionComponentInstances);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("api/public/productionComponentInstances/bulkInsert", requestContent);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<Bundle>(content);
    }

    public async Task<List<ProductionComponentInstance>> AddToBatch(
        Guid batchGuid,
        List<Guid> productionComponentInstanceGuids
    )
    {
        var requestBody = Serialization.Serialize(new { productionComponentInstanceGuids, batchGuid });
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.SendAsync(
            new HttpRequestMessage(new HttpMethod("PATCH"), "api/public/productionComponentInstances/addToBatch")
            {
                Content = requestContent,
            }
        );
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<ProductionComponentInstance>>(content);
    }

    public async Task<List<ProductionComponentInstance>> RemoveFromBatch(List<Guid> productionComponentInstanceGuids)
    {
        var requestBody = Serialization.Serialize(productionComponentInstanceGuids);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.SendAsync(
            new HttpRequestMessage(new HttpMethod("PATCH"), "api/public/productionComponentInstances/removeFromBatch")
            {
                Content = requestContent,
            }
        );
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<ProductionComponentInstance>>(content);
    }

    public async Task<List<ProductionComponentInstance>> AppendToBundle(
        Guid bundleGuid,
        List<Guid> productionComponentInstanceGuids
    )
    {
        var requestBody = Serialization.Serialize(new { productionComponentInstanceGuids, batchGuid = bundleGuid });
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.SendAsync(
            new HttpRequestMessage(new HttpMethod("PATCH"), "api/public/productionComponentInstances/appendToBundle")
            {
                Content = requestContent,
            }
        );
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<ProductionComponentInstance>>(content);
    }

    public async Task<List<ProductionComponentInstance>> RemoveFromBundle(List<Guid> productionComponentInstanceGuids)
    {
        var requestBody = Serialization.Serialize(productionComponentInstanceGuids);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.SendAsync(
            new HttpRequestMessage(new HttpMethod("PATCH"), "api/public/productionComponentInstances/removeFromBundle")
            {
                Content = requestContent,
            }
        );
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<ProductionComponentInstance>>(content);
    }

    public async Task SetStatus(List<Guid> productionComponentInstanceGuids, ProductionComponentInstanceStatus status)
    {
        var requestBody = Serialization.Serialize(new { productionComponentInstanceGuids, status });
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.SendAsync(
            new HttpRequestMessage(new HttpMethod("PATCH"), "api/public/productionComponentInstances/setStatus")
            {
                Content = requestContent,
            }
        );
        response.EnsureSuccessStatusCode();
    }
}
