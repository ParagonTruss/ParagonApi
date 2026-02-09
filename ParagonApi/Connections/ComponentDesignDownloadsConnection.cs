namespace ParagonApi.Connections;

public class ComponentDesignDownloadsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<HttpResponseMessage> BvnFile(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/bvn", downloadRequest);

    public Task<HttpResponseMessage> IfcFile(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/ifc", downloadRequest);

    public Task<HttpResponseMessage> OmnFile(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/omn", downloadRequest);

    public Task<HttpResponseMessage> TpsFile(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/tps", downloadRequest);

    public Task<HttpResponseMessage> TreFile(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/tre", downloadRequest);

    public Task<HttpResponseMessage> TrsFile(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/trs", downloadRequest);

    public Task<HttpResponseMessage> MachineryTrsFile(DownloadMachineryTrsRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/machineryTrs", downloadRequest);

    public Task<HttpResponseMessage> ComponentReport(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/componentReport", downloadRequest);

    public Task<HttpResponseMessage> LumberPickList(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/lumberPickList", downloadRequest);

    public Task<HttpResponseMessage> MaterialReportCsv(DownloadMaterialReportRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/materialReportCsv", downloadRequest);

    public Task<HttpResponseMessage> MaterialReportPdf(DownloadMaterialReportRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/materialReportPdf", downloadRequest);

    public Task<HttpResponseMessage> PlatePickList(DownloadRequest downloadRequest) =>
        Client.PostRawResponse("api/public/trusses/download/platePickList", downloadRequest);
}
