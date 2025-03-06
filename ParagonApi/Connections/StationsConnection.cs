namespace ParagonApi.Connections;

public class StationsConnection
{
    private HttpClient Client { get; }

    public StationsConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    public async Task<List<Station>> FindAll()
    {
        var response = await Client.GetAsync("/api/public/stations/");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<Station>>(responseContent);
    }

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

    public async Task UploadCountFile(Guid stationGuid, BinaryUploadFile file)
    {
        var url = $"/api/public/stations/{stationGuid}/countFile";
        var requestBody = Serialization.Serialize(file.ToBase64File());
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await Client.PutAsync(url, requestContent);
        response.EnsureSuccessStatusCode();
    }

    public async Task OrderStationComponentDesigns(Guid stationGuid, List<Guid> orderedStationComponentDesigns)
    {
        var url = $"/api/public/stations/{stationGuid}/order";
        var requestBody = Serialization.Serialize(new { orderedStationComponentDesigns });
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await Client.PutAsync(url, requestContent);
        response.EnsureSuccessStatusCode();
    }

    public async Task Clear(Guid stationGuid)
    {
        var url = $"/api/public/stations/{stationGuid}/componentDesigns/";
        var response = await Client.DeleteAsync(url);

        response.EnsureSuccessStatusCode();
    }

    public async Task SetCurrentProductionComponentInstanceGuid(
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
        var response = await Client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), url));

        response.EnsureSuccessStatusCode();
    }
}
