namespace ParagonApi.Connections;

public class BatchesConnection
{
    private HttpClient Client { get; }

    public BatchesConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    public async Task<Batch> Find(Guid guid)
    {
        var response = await Client.GetAsync($"api/public/batches/{guid}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<Batch>(content);
    }

    public async Task<List<Batch>> FindForProductionGroup(Guid productionGroupGuid)
    {
        var response = await Client.GetAsync($"api/public/batches/forProductionGroup/{productionGroupGuid}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<Batch>>(content);
    }

    public async Task<Batch> Insert(Batch batch)
    {
        var requestBody = Serialization.Serialize(batch);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("api/public/batches", requestContent);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<Batch>(content);
    }

    public async Task Delete(Guid batchGuid)
    {
        var response = await Client.DeleteAsync($"api/public/batches/{batchGuid}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<List<string>> ParseComponentsFromBatchInCountFile(string batchName, Base64File cntFile)
    {
        var url = $"api/countUtilities/parseComponentsFromBatchInCountFile";

        var requestBody = Serialization.Serialize(new { BatchName = batchName, CntFile = cntFile });
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(url, requestContent);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<string>>(content);
    }
}
