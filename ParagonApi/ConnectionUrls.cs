namespace ParagonApi;

public class ConnectionUrls
{
    public required Uri DesignServiceUri { get; set; }
    public required Uri SealingServiceUri { get; set; }
    public required Uri SyncServiceUri { get; set; }
    public required Uri UserServiceUri { get; set; }
    public required Uri ParagonServicesUri { get; set; }
    public required Uri DesignClientUri { get; set; }

    public static ConnectionUrls Default =>
        new ConnectionUrls
        {
            DesignServiceUri = new Uri("https://designserver.paragontruss.com/"),
            SealingServiceUri = new Uri("https://sealingserver.paragontruss.com/"),
            SyncServiceUri = new Uri("wss://sync.paragontruss.com/"),
            UserServiceUri = new Uri("https://auth.paragontruss.com/"),
            ParagonServicesUri = new Uri("https://services.paragontruss.com/"),
            DesignClientUri = new Uri("https://design.paragontruss.com/"),
        };
}
