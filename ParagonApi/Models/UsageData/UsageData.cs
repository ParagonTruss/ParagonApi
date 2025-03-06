namespace ParagonApi.Models;

public enum LoggedUsages
{
    // Downloads
    TddDownload,
    JointQCDownload,
    DigitalQCDownload,
    ShopDrawingDownload,

    // Process Requests
    TrussCreate,
    ProjectCreate,
    FullAnalysis,
}

public class UsageDataForOrganization
{
    public required int Year { get; set; }
    public required int Month { get; set; }
    public required string Organization { get; set; }
    public required LoggedUsages Usage { get; set; }
    public required int Instances { get; set; }
}

public class UsageData : UsageDataForOrganization
{
    public required string Location { get; set; }
    public required string UserIdentifier { get; set; }
}
