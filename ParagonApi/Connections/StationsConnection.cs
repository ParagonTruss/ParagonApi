namespace ParagonApi.Connections;

public class StationsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<List<Station>> FindAll() => Client.Get<List<Station>>("/api/public/stations/");

    public async Task<bool> Exists(Guid stationGuid)
    {
        return await FindOrDefault(stationGuid) != null;
    }

    public async Task<Station> Find(Guid stationGuid)
    {
        return await FindInternal(stationGuid, false) ?? throw new NullReferenceException();
    }

    public Task<Station?> FindOrDefault(Guid stationGuid)
    {
        return FindInternal(stationGuid, true);
    }

    private async Task<Station?> FindInternal(Guid stationGuid, bool allowNull)
    {
        var response = await Client.GetAsync($"/api/public/stations/{stationGuid}");

        if (allowNull)
        {
            if (!response.IsSuccessStatusCode)
                return null;
        }
        else
        {
            response.EnsureSuccessStatusCode();
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<Station>(responseContent);
    }

    public async Task<Station> FindByName(string stationName)
    {
        return await FindByNameInternal(stationName, false) ?? throw new NullReferenceException();
    }

    public Task<Station?> FindByNameOrDefault(string stationName)
    {
        return FindByNameInternal(stationName, true);
    }

    private async Task<Station?> FindByNameInternal(string stationName, bool allowNull)
    {
        var url = $"/api/public/stations/search?name={WebUtility.UrlEncode(stationName)}";

        var response = await Client.GetAsync(url);
        if (allowNull)
        {
            if (!response.IsSuccessStatusCode)
                return null;
        }
        else
        {
            response.EnsureSuccessStatusCode();
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<Station>(responseContent);
    }

    public async Task AddComponentDesign(Guid stationGuid, Guid componentDesignGuid)
    {
        var url = $"/api/public/stations/{stationGuid}/componentDesigns/{componentDesignGuid}";
        var response = await Client.PostAsync(url, null);

        response.EnsureSuccessStatusCode();
    }

    public Task UploadCountFile(Guid stationGuid, BinaryUploadFile file) =>
        Client.Put($"/api/public/stations/{stationGuid}/countFile", file.ToBase64File());

    public Task OrderStationComponentDesigns(Guid stationGuid, List<Guid> orderedStationComponentDesigns) =>
        Client.Put(
            $"/api/public/stations/{stationGuid}/order",
            new OrderStationComponentDesignRequest { OrderedStationComponentDesigns = orderedStationComponentDesigns }
        );

    public Task Clear(Guid stationGuid) => Client.Delete($"/api/public/stations/{stationGuid}/componentDesigns/");

    public Task SetCurrentProductionComponentInstanceGuid(
        Guid stationGuid,
        Guid? newProductionComponentInstanceGuid,
        ProductionComponentInstanceStatus? newStatus
    )
    {
        var queryParameters = newStatus.HasValue ? $"?newStatus={newStatus.ToString()}" : "";
        var newProductionComponentInstanceGuidParameter = newProductionComponentInstanceGuid.HasValue
            ? newProductionComponentInstanceGuid.Value.ToString()
            : "";
        var url =
            $"/api/public/stations/{stationGuid}/setCurrentProductionComponentInstanceGuid/{newProductionComponentInstanceGuidParameter}{queryParameters}";

        return Client.Patch(url);
    }
}
