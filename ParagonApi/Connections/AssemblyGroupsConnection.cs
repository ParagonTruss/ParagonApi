namespace ParagonApi.Connections;

public class AssemblyGroupsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<List<AssemblyGroup>> FindAll() => Client.Get<List<AssemblyGroup>>("/api/public/assemblyGroups/");

    public Task<AssemblyGroup> Find(Guid assemblyGroupGuid) =>
        Client.Get<AssemblyGroup>($"/api/public/assemblyGroups/{assemblyGroupGuid}");

    public Task<AssemblyGroup> Insert(CreateAssemblyGroupRequest request) =>
        Client.Post<CreateAssemblyGroupRequest, AssemblyGroup>("/api/public/assemblyGroups", request);

    public Task<AssemblyGroup> InsertFromLookupCode(CreateAssemblyGroupFromLookupCodeRequest request) =>
        Client.Post<CreateAssemblyGroupFromLookupCodeRequest, AssemblyGroup>(
            "/api/public/assemblyGroups/fromLookupCode",
            request
        );

    public Task<AssemblyGroup> Update(Guid assemblyGroupGuid, UpdateAssemblyGroupShallowRequest request) =>
        Client.Put<UpdateAssemblyGroupShallowRequest, AssemblyGroup>(
            $"/api/public/assemblyGroups/{assemblyGroupGuid}",
            request
        );

    public Task<AssemblyGroup> PutComponentDesigns(
        Guid assemblyGroupGuid,
        Dictionary<Guid, StationComponentDesign> componentDesigns
    ) =>
        Client.Put<Dictionary<Guid, StationComponentDesign>, AssemblyGroup>(
            $"/api/public/assemblyGroups/{assemblyGroupGuid}/componentDesigns",
            componentDesigns
        );
}
