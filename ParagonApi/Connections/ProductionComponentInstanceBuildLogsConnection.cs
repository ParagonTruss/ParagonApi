namespace ParagonApi.Connections;

public class ProductionComponentInstanceBuildLogsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<List<ProductionComponentInstanceBuildLog>> FindByProductionComponentIstanceGuid(
        Guid productionComponentInstanceGuid
    ) => FindByProductionComponentInstanceGuids(new List<Guid> { productionComponentInstanceGuid });

    public Task<List<ProductionComponentInstanceBuildLog>> FindByProductionComponentInstanceGuids(
        List<Guid> productionComponentInstanceGuids
    ) =>
        Client.Post<List<Guid>, List<ProductionComponentInstanceBuildLog>>(
            "api/public/productionComponentInstanceBuildLogs/getBuildLogsForProductionComponentInstances",
            productionComponentInstanceGuids
        );

    public Task<List<ProductionComponentInstanceBuildLog>> FindByStationGuid(
        Guid stationGuid,
        DateTime? startDateInclusive,
        DateTime? endDateInclusive
    )
    {
        var startDateQueryString = startDateInclusive.HasValue
            ? $"startDateInclusive={startDateInclusive.Value:s}"
            : null;
        var endDateQueryString = endDateInclusive.HasValue ? $"endDateInclusive={endDateInclusive.Value:s}" : null;
        var queryString =
            startDateInclusive.HasValue || endDateInclusive.HasValue
                ? $"?{startDateQueryString ?? ""}{(startDateInclusive.HasValue && endDateInclusive.HasValue ? "&" : "")}{endDateQueryString ?? ""}"
                : "";

        return Client.Get<List<ProductionComponentInstanceBuildLog>>(
            $"api/public/productionComponentInstanceBuildLogs/byStationGuid/{stationGuid}{queryString}"
        );
    }

    public Task<ProductionMetrics> GetCompletedMetricsForStation(
        Guid stationGuid,
        DateTime? startDateInclusive,
        DateTime? endDateInclusive
    )
    {
        var startDateQueryString = startDateInclusive.HasValue
            ? $"startDateInclusive={startDateInclusive.Value:s}"
            : null;
        var endDateQueryString = endDateInclusive.HasValue ? $"endDateInclusive={endDateInclusive.Value:s}" : null;
        var queryString =
            startDateInclusive.HasValue || endDateInclusive.HasValue
                ? $"?{startDateQueryString ?? ""}{(startDateInclusive.HasValue && endDateInclusive.HasValue ? "&" : "")}{endDateQueryString ?? ""}"
                : "";

        return Client.Get<ProductionMetrics>(
            $"api/public/productionComponentInstanceBuildLogs/completedMetricsByStationGuid/{stationGuid}{queryString}"
        );
    }

    public Task SetStartProduction(
        Guid productionComponentInstanceGuid,
        Guid stationGuid,
        DateTime startProduction,
        bool enableOverwrite
    ) =>
        Client.Post(
            "api/public/productionComponentInstanceBuildLogs/setStartProduction",
            new SetStartProductionRequest
            {
                ProductionComponentInstanceGuid = productionComponentInstanceGuid,
                StationGuid = stationGuid,
                StartProduction = startProduction,
                EnableOverwrite = enableOverwrite,
            }
        );

    public Task SetEndProduction(
        Guid productionComponentInstanceGuid,
        Guid stationGuid,
        DateTime endProduction,
        bool enableOverwrite
    ) =>
        Client.Post(
            "api/public/productionComponentInstanceBuildLogs/setEndProduction",
            new SetEndProductionRequest
            {
                ProductionComponentInstanceGuid = productionComponentInstanceGuid,
                StationGuid = stationGuid,
                EndProduction = endProduction,
                EnableOverwrite = enableOverwrite,
            }
        );
}
