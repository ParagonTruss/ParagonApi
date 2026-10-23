namespace ParagonApi.Connections;

public class PlatePricesConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<List<PlatePrice>> GetAll() => Client.Get<List<PlatePrice>>("api/public/platePrices");

    public async Task<PlatePrice?> GetMostRecent(PlateType plateType)
    {
        var response = await Client.GetAsync(
            $"api/public/platePrices/{Uri.EscapeDataString(plateType.ToString())}/mostRecent"
        );
        response.EnsureSuccessStatusCode();

        if (response.StatusCode == HttpStatusCode.NoContent)
            return null;

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<PlatePrice>(content);
    }

    public Task<PlatePrice> Insert(NewPlatePrice newPlatePrice) =>
        Client.Post<NewPlatePrice, PlatePrice>("api/public/platePrices", newPlatePrice);

    public Task<List<PlatePrice>> BulkInsert(List<NewPlatePrice> newPlatePrices) =>
        Client.Post<List<NewPlatePrice>, List<PlatePrice>>("api/public/platePrices/bulk", newPlatePrices);

    public Task<PlatePrice> Update(PlatePriceEdit platePriceEdit) =>
        Client.Put<PlatePriceEdit, PlatePrice>("api/public/platePrices", platePriceEdit);

    public Task<List<PlatePrice>> BulkUpdate(List<PlatePriceEdit> platePriceEdits) =>
        Client.Put<List<PlatePriceEdit>, List<PlatePrice>>("api/public/platePrices/bulk", platePriceEdits);
}
