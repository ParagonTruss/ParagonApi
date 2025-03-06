namespace ParagonApi;

public class Paragon : IDisposable
{
    public UsageDataConnection UsageData { get; }
    public StationsConnection Stations { get; }
    public TrussesConnection Trusses { get; }
    public BatchesConnection Batches { get; }
    public BundlesConnection Bundles { get; }
    public ProductionComponentInstancesConnection ProductionComponentInstances { get; }
    public ProductionComponentInstanceBuildLogsConnection ProductionComponentInstanceBuildLogs { get; }
    public ProductionGroupsConnection ProductionGroups { get; }
    public ScheduleLineGroupsConnection ScheduleLineGroups { get; }
    public ProjectsConnection Projects { get; }
    public LayoutsConnection Layouts { get; }
    public AnalysisSetsConnection AnalysisSets { get; }

    public JobsConnection Jobs { get; }

    private HttpClient DesignServiceClient { get; }
    private HttpClient UserServiceClient { get; }
    private HttpClient SealingServiceClient { get; }

    private Paragon(ConnectionUrls connectionUrls, string jwtToken)
    {
        DesignServiceClient = new HttpClient { BaseAddress = connectionUrls.DesignServiceUri };
        UserServiceClient = new HttpClient { BaseAddress = connectionUrls.UserServiceUri };
        SealingServiceClient = new HttpClient { BaseAddress = connectionUrls.SealingServiceUri };

        var jwtHeaderValue = new AuthenticationHeaderValue("JWT", jwtToken);
        UserServiceClient.DefaultRequestHeaders.Authorization = jwtHeaderValue;
        DesignServiceClient.DefaultRequestHeaders.Authorization = jwtHeaderValue;

        UsageData = new UsageDataConnection(DesignServiceClient);
        Stations = new StationsConnection(DesignServiceClient);
        Trusses = new TrussesConnection(DesignServiceClient);
        Batches = new BatchesConnection(DesignServiceClient);
        Bundles = new BundlesConnection(DesignServiceClient);
        ProductionComponentInstances = new ProductionComponentInstancesConnection(DesignServiceClient);
        ProductionComponentInstanceBuildLogs = new ProductionComponentInstanceBuildLogsConnection(DesignServiceClient);
        ProductionGroups = new ProductionGroupsConnection(DesignServiceClient);
        ScheduleLineGroups = new ScheduleLineGroupsConnection(DesignServiceClient);
        Projects = new ProjectsConnection(DesignServiceClient);
        Layouts = new LayoutsConnection(DesignServiceClient);
        AnalysisSets = new AnalysisSetsConnection(DesignServiceClient);

        Jobs = new JobsConnection(SealingServiceClient);
    }

    public static Task<Paragon> Connect()
    {
        return Connect(new ParagonApiConfiguration());
    }

    public static Task<Paragon> Connect(ConnectionUrls urls)
    {
        return Connect(new ParagonApiConfiguration { Urls = urls });
    }

    public static async Task<Paragon> Connect(ParagonApiConfiguration configuration)
    {
        return new Paragon(
            configuration.Urls,
            configuration.JwtToken ?? await ParagonApiAuthorizer.ObtainJwtToken(configuration)
        );
    }

    public void Dispose()
    {
        DesignServiceClient.Dispose();
        UserServiceClient.Dispose();
        SealingServiceClient.Dispose();
    }
}
