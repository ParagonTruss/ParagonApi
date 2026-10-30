namespace ParagonApi.Connections;

public class ComponentDesignDownloadsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<HttpResponseMessage> BvnFile(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/bvn", downloadRequest);

    public Task<HttpResponseMessage> IfcFile(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/ifc", downloadRequest);

    public Task<HttpResponseMessage> OmnFile(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/omn", downloadRequest);

    public Task<HttpResponseMessage> TpsFile(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/tps", downloadRequest);

    public Task<HttpResponseMessage> TreFile(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/tre", downloadRequest);

    public Task<HttpResponseMessage> MachineryTrsFile(DownloadMachineryTrsRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/machineryTrs", downloadRequest);

    public Task<HttpResponseMessage> ShopDrawings(DownloadShopDrawingsRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/shopDrawings", downloadRequest);

    public Task<HttpResponseMessage> ComponentReport(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/componentReport", downloadRequest);

    public Task<HttpResponseMessage> LumberPickList(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/lumberPickList", downloadRequest);

    public Task<HttpResponseMessage> MaterialReportCsv(DownloadMaterialReportRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/materialReportCsv", downloadRequest);

    public Task<HttpResponseMessage> MaterialReportPdf(DownloadMaterialReportRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/materialReportPdf", downloadRequest);

    public Task<HttpResponseMessage> PlatePickList(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/platePickList", downloadRequest);

    public Task<HttpResponseMessage> TrussDesignDrawings(DownloadTrussDesignDrawingsRequest downloadRequest) =>
        Client.PostRawResponse("api/public/componentDesigns/download/trussDesignDrawings", downloadRequest);
}
