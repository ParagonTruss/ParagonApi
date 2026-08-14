namespace ParagonApi.Connections;

public class LumberListsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<List<LumberList>> FindAll() => Client.Get<List<LumberList>>("api/public/lumberLists");

    public Task<LumberList> Find(Guid lumberListGuid) =>
        Client.Get<LumberList>($"api/public/lumberLists/{lumberListGuid}");

    public Task<LumberList> Insert(NewLumberList newLumberList) =>
        Client.Post<NewLumberList, LumberList>("api/public/lumberLists", newLumberList);

    public Task<LumberList> Update(LumberList lumberList) =>
        Client.Put<LumberList, LumberList>("api/public/lumberLists", lumberList);

    public Task<LumberList> Archive(Guid lumberListGuid) =>
        Client.Delete<LumberList>($"api/public/lumberLists/{lumberListGuid}");

    public Task<LumberList> Restore(Guid lumberListGuid) =>
        Client.PostNoContent<LumberList>($"api/public/lumberLists/{lumberListGuid}/restore");

    public Task SetDefault(Guid lumberListGuid) =>
        Client.PostNoContent($"api/public/lumberLists/{lumberListGuid}/setAsDefault");
}
