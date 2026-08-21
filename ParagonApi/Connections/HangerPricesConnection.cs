namespace ParagonApi.Connections;

public class HangerPricesConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<List<HangerPrice>> GetAll() => Client.Get<List<HangerPrice>>("api/public/hangerPrices");

    public async Task<HangerPrice?> GetMostRecent(StandardConnectingHardwareModel hanger)
    {
        var response = await Client.GetAsync($"api/public/hangerPrices/{hanger}/mostRecent");
        response.EnsureSuccessStatusCode();

        if (response.StatusCode == HttpStatusCode.NoContent)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<HangerPrice>(content);
    }

    public Task<HangerPrice> Insert(NewHangerPrice newHangerPrice) =>
        Client.Post<NewHangerPrice, HangerPrice>("api/public/hangerPrices", newHangerPrice);

    public Task<List<HangerPrice>> BulkInsert(List<NewHangerPrice> newHangerPrices) =>
        Client.Post<List<NewHangerPrice>, List<HangerPrice>>("api/public/hangerPrices/bulkInsert", newHangerPrices);

    public Task<HangerPrice> Update(HangerPriceEdit hangerPriceEdit) =>
        Client.Put<HangerPriceEdit, HangerPrice>("api/public/hangerPrices", hangerPriceEdit);
}
