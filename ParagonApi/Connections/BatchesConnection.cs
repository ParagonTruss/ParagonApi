namespace ParagonApi.Connections;

public class BatchesConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<Batch> Find(Guid guid) => Client.Get<Batch>($"api/public/batches/{guid}");

    public Task<List<Batch>> FindForProductionGroup(Guid productionGroupGuid) =>
        Client.Get<List<Batch>>($"api/public/batches/forProductionGroup/{productionGroupGuid}");

    public Task<Batch> Insert(Batch batch) => Client.Post<Batch, Batch>($"api/public/batches", batch);

    public Task Delete(Guid batchGuid) => Client.Delete($"api/public/batches/{batchGuid}");

    public Task<List<string>> ParseComponentsFromBatchInCountFile(string batchName, Base64File cntFile) =>
        Client.Post<ParseComponentsFromBatchRequest, List<string>>(
            // FIXME This route is not part of the public API
            "api/countUtilities/parseComponentsFromBatchInCountFile",
            new ParseComponentsFromBatchRequest { BatchName = batchName, CntFile = cntFile }
        );
}
