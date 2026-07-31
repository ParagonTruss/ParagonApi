namespace ParagonApi.Connections;

public class PlateListsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<List<PlateList>> FindAll() => Client.Get<List<PlateList>>("api/public/plateLists");

    public Task<PlateList> Find(Guid plateListGuid) => Client.Get<PlateList>($"api/public/plateLists/{plateListGuid}");

    public Task<PlateList> Insert(NewPlateList newPlateList) =>
        Client.Post<NewPlateList, PlateList>("api/public/plateLists", newPlateList);

    public Task<PlateList> Update(PlateList plateList) =>
        Client.Put<PlateList, PlateList>("api/public/plateLists", plateList);

    public Task<PlateList> Archive(Guid plateListGuid) =>
        Client.Delete<PlateList>($"api/public/plateLists/{plateListGuid}");

    public Task<PlateList> Restore(Guid plateListGuid) =>
        Client.PostNoContent<PlateList>($"api/public/plateLists/{plateListGuid}/restore");

    public Task SetDefault(Guid plateListGuid) =>
        Client.PostNoContent($"api/public/plateLists/{plateListGuid}/setAsDefault");
}
