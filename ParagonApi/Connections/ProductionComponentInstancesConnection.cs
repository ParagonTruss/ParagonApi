namespace ParagonApi.Connections;

public class ProductionComponentInstancesConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<ProductionComponentInstance> Find(Guid guid) =>
        Client.Get<ProductionComponentInstance>($"api/public/productionComponentInstances/{guid}");

    public Task<List<ProductionComponentInstance>> FindForProductionGroup(Guid productionGroupGuid) =>
        Client.Get<List<ProductionComponentInstance>>(
            $"api/public/productionComponentInstances/forProductionGroup/{productionGroupGuid}"
        );

    public Task<Bundle> BulkInsert(List<ProductionComponentInstance> productionComponentInstances) =>
        Client.Post<List<ProductionComponentInstance>, Bundle>(
            "api/public/productionComponentInstances/bulkInsert",
            productionComponentInstances
        );

    public Task<List<ProductionComponentInstance>> AddToBatch(
        Guid batchGuid,
        List<Guid> productionComponentInstanceGuids
    ) =>
        Client.Patch<AddToBatchRequest, List<ProductionComponentInstance>>(
            "api/public/productionComponentInstances/addToBatch",
            new AddToBatchRequest
            {
                BatchGuid = batchGuid,
                ProductionComponentInstanceGuids = productionComponentInstanceGuids,
            }
        );

    public Task<List<ProductionComponentInstance>> RemoveFromBatch(List<Guid> productionComponentInstanceGuids) =>
        Client.Patch<List<Guid>, List<ProductionComponentInstance>>(
            "api/public/productionComponentInstances/removeFromBatch",
            productionComponentInstanceGuids
        );

    public Task<List<ProductionComponentInstance>> AppendToBundle(
        Guid bundleGuid,
        Dictionary<Guid, Point2D> instancePositions
    ) =>
        Client.Patch<AppendToBundleRequest, List<ProductionComponentInstance>>(
            "api/public/productionComponentInstances/appendToBundle",
            new AppendToBundleRequest { BundleGuid = bundleGuid, InstancePositions = instancePositions }
        );

    public Task<List<ProductionComponentInstance>> RemoveFromBundle(List<Guid> productionComponentInstanceGuids) =>
        Client.Patch<List<Guid>, List<ProductionComponentInstance>>(
            "api/public/productionComponentInstances/removeFromBundle",
            productionComponentInstanceGuids
        );

    public Task SetStatus(List<Guid> productionComponentInstanceGuids, ProductionComponentInstanceStatus status) =>
        Client.Patch(
            "api/public/productionComponentInstances/setStatus",
            new SetStatusRequest
            {
                ProductionComponentInstanceGuids = productionComponentInstanceGuids,
                Status = status,
            }
        );
}
