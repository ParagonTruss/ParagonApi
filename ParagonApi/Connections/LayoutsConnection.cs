namespace ParagonApi.Connections;

public class LayoutsConnection
{
    private HttpClient Client { get; }

    public LayoutsConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    public async Task<BearingEnvelope> CreateBearingEnvelope(Guid projectGuid, NewBearingEnvelope bearingEnvelope)
    {
        var requestBody = Serialization.Serialize(bearingEnvelope);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync($"api/public/projects/{projectGuid}/bearingEnvelopes", requestContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<BearingEnvelope>(responseContent);
    }

    public async Task<RoofPlane> CreateRoofPlane(Guid projectGuid, NewRoofPlane roofPlane)
    {
        var requestBody = Serialization.Serialize(roofPlane);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync($"api/public/projects/{projectGuid}/roofPlanes", requestContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<RoofPlane>(responseContent);
    }

    public async Task<RoofPlane> UpdateRoofPlane(Guid projectGuid, RoofPlane roofPlane)
    {
        var requestBody = Serialization.Serialize(roofPlane);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PutAsync($"api/public/projects/{projectGuid}/roofPlanes", requestContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<RoofPlane>(responseContent);
    }

    public async Task<RoofContainer> CreateRoofContainer(Guid projectGuid, NewRoofContainer roofContainer)
    {
        var requestBody = Serialization.Serialize(roofContainer);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync($"api/public/projects/{projectGuid}/roofContainers", requestContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<RoofContainer>(responseContent);
    }

    public async Task<TrussEnvelope> CreateTrussEnvelope(Guid projectGuid, NewTrussEnvelope trussEnvelope)
    {
        var requestBody = Serialization.Serialize(trussEnvelope);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync($"api/public/projects/{projectGuid}/trussEnvelopes", requestContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<TrussEnvelope>(responseContent);
    }

    public async Task<List<TrussEnvelope>> CreateTrusses(Guid projectGuid, List<Guid> trussEnvelopeGuids)
    {
        var requestBody = Serialization.Serialize(trussEnvelopeGuids);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync($"api/public/projects/{projectGuid}/createTrusses", requestContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<TrussEnvelope>>(responseContent);
    }
}
