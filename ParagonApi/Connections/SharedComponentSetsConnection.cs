namespace ParagonApi.Connections;

public class SharedComponentSetsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<SharedComponentSet> Create(CreateSharedComponentSetRequest request) =>
        Client.Post<CreateSharedComponentSetRequest, SharedComponentSet>("/api/public/sharedComponentSets", request);
}
