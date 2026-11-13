namespace ParagonApi.Connections;

public class LayoutsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<List<BearingEnvelope>> GetBearingEnvelopes(Guid projectGuid) =>
        Client.Get<List<BearingEnvelope>>($"api/public/projects/{projectGuid}/bearingEnvelopes");

    public Task<BearingEnvelope> CreateBearingEnvelope(Guid projectGuid, NewBearingEnvelope bearingEnvelope) =>
        Client.Post<NewBearingEnvelope, BearingEnvelope>(
            $"api/public/projects/{projectGuid}/bearingEnvelopes",
            bearingEnvelope
        );

    public Task<List<RoofPlane>> GetRoofPlanes(Guid projectGuid) =>
        Client.Get<List<RoofPlane>>($"api/public/projects/{projectGuid}/roofPlanes");

    public Task<RoofPlane> CreateRoofPlane(Guid projectGuid, NewRoofPlane roofPlane) =>
        Client.Post<NewRoofPlane, RoofPlane>($"api/public/projects/{projectGuid}/roofPlanes", roofPlane);

    public Task<List<RoofPlane>> CreateRoofPlanesFromFaces(Guid projectGuid, List<LayoutFace> faces) =>
        Client.Post<List<LayoutFace>, List<RoofPlane>>(
            $"api/public/projects/{projectGuid}/roofPlanes/fromFaces",
            faces
        );

    public Task<RoofPlane> UpdateRoofPlane(Guid projectGuid, RoofPlane roofPlane) =>
        Client.Put<RoofPlane, RoofPlane>($"api/public/projects/{projectGuid}/roofPlanes", roofPlane);

    public Task<List<CeilingPlane>> GetCeilingPlanes(Guid projectGuid) =>
        Client.Get<List<CeilingPlane>>($"api/public/projects/{projectGuid}/ceilingPlanes");

    public Task<CeilingPlane> CreateCeilingPlane(Guid projectGuid, NewCeilingPlane ceilingPlane) =>
        Client.Post<NewCeilingPlane, CeilingPlane>($"api/public/projects/{projectGuid}/ceilingPlanes", ceilingPlane);

    public Task<List<CeilingPlane>> CreateCeilingPlanesFromFaces(Guid projectGuid, List<LayoutFace> faces) =>
        Client.Post<List<LayoutFace>, List<CeilingPlane>>(
            $"api/public/projects/{projectGuid}/ceilingPlanes/fromFaces",
            faces
        );

    public Task<CeilingPlane> UpdateCeilingPlane(Guid projectGuid, CeilingPlane ceilingPlane) =>
        Client.Put<CeilingPlane, CeilingPlane>($"api/public/projects/{projectGuid}/ceilingPlanes", ceilingPlane);

    public Task<RoofContainer> CreateRoofContainer(Guid projectGuid, NewRoofContainer roofContainer) =>
        Client.Post<NewRoofContainer, RoofContainer>(
            $"api/public/projects/{projectGuid}/roofContainers",
            roofContainer
        );

    public Task<List<TrussEnvelope>> GetTrussEnvelopes(Guid projectGuid) =>
        Client.Get<List<TrussEnvelope>>($"api/public/projects/{projectGuid}/trussEnvelopes");

    public Task<TrussEnvelope> CreateTrussEnvelope(Guid projectGuid, NewTrussEnvelope trussEnvelope) =>
        Client.Post<NewTrussEnvelope, TrussEnvelope>(
            $"api/public/projects/{projectGuid}/trussEnvelopes",
            trussEnvelope
        );

    public Task<List<TrussEnvelope>> CreateTrusses(Guid projectGuid, List<Guid> trussEnvelopeGuids) =>
        Client.Post<List<Guid>, List<TrussEnvelope>>(
            $"api/public/projects/{projectGuid}/createTrusses",
            trussEnvelopeGuids
        );
}
