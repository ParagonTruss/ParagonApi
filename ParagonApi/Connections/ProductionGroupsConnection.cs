namespace ParagonApi.Connections;

public class ProductionGroupsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<ProductionGroup> Find(Guid guid) => Client.Get<ProductionGroup>($"api/public/productionGroups/{guid}");

    public Task<List<ProductionGroup>> FindForProject(Guid projectGuid) =>
        Client.Get<List<ProductionGroup>>($"api/public/productionGroups/forProject/{projectGuid}");

    public Task Insert(ProductionGroup productionGroup) => Client.Post("api/public/productionGroups", productionGroup);
}
