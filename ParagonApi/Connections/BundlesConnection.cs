namespace ParagonApi.Connections;

public class BundlesConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<Bundle> Find(Guid guid) => Client.Get<Bundle>($"api/public/bundles/{guid}");

    public Task<List<Bundle>> FindForProductionGroup(Guid productionGroupGuid) =>
        Client.Get<List<Bundle>>($"api/public/bundles/forProductionGroup/{productionGroupGuid}");

    public Task<Bundle> Insert(Bundle bundle) => Client.Post<Bundle, Bundle>("api/public/bundles", bundle);

    public Task Delete(Guid bundleGuid) => Client.Delete($"api/public/bundles/{bundleGuid}");

    public Task FinishComponentsForBundles(List<Guid> bundleGuids) =>
        Client.Post("api/public/bundles/finishComponentsForBundles", bundleGuids);
}
