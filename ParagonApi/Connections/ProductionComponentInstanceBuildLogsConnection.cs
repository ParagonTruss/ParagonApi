namespace ParagonApi.Connections;

public class ProductionComponentInstanceBuildLogsConnection
{
    private HttpClient Client { get; }

    public ProductionComponentInstanceBuildLogsConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    public Task<List<ProductionComponentInstanceBuildLog>> FindByProductionComponentInstanceGuid(
        Guid productionComponentInstanceGuid
    ) => FindByProductionComponentInstanceGuids(new List<Guid> { productionComponentInstanceGuid });

    public async Task<List<ProductionComponentInstanceBuildLog>> FindByProductionComponentInstanceGuids(
        List<Guid> productionComponentInstanceGuids
    )
    {
        var requestBody = Serialization.Serialize(productionComponentInstanceGuids);
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(
            "api/public/productionComponentInstanceBuildLogs/getBuildLogsForProductionComponentInstances",
            requestContent
        );

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<ProductionComponentInstanceBuildLog>>(content);
    }

    public async Task<List<ProductionComponentInstanceBuildLog>> FindByStationGuid(
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
        var response = await Client.GetAsync(
            $"api/public/productionComponentInstanceBuildLogs/byStationGuid/{stationGuid}{queryString}"
        );
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<ProductionComponentInstanceBuildLog>>(content);
    }

    public async Task<ProductionMetrics> GetCompletedMetricsForStation(
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
        var response = await Client.GetAsync(
            $"api/public/productionComponentInstanceBuildLogs/completedMetricsByStationGuid/{stationGuid}{queryString}"
        );
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<ProductionMetrics>(content);
    }

    public async Task SetStartProduction(
        Guid productionComponentInstanceGuid,
        Guid stationGuid,
        DateTime startProduction,
        bool enableOverwrite
    )
    {
        var requestBody = Serialization.Serialize(
            new
            {
                productionComponentInstanceGuid,
                stationGuid,
                startProduction,
                enableOverwrite,
            }
        );
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(
            "api/public/productionComponentInstanceBuildLogs/setStartProduction",
            requestContent
        );
        response.EnsureSuccessStatusCode();
    }

    public async Task SetEndProduction(
        Guid productionComponentInstanceGuid,
        Guid stationGuid,
        DateTime endProduction,
        bool enableOverwrite
    )
    {
        var requestBody = Serialization.Serialize(
            new
            {
                productionComponentInstanceGuid,
                stationGuid,
                endProduction,
                enableOverwrite,
            }
        );
        var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(
            "api/public/productionComponentInstanceBuildLogs/setEndProduction",
            requestContent
        );
        response.EnsureSuccessStatusCode();
    }
}
