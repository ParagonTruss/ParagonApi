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
    Analysis,
}

public enum UsageCheck
{
    TrussDesigns,
}

public class UsageQuota
{
    /// <summary>
    /// Different from <see cref="ParagonApi.Models.LoggedUsages"/> since some calculation might be required from the
    /// logs to derive the usage.
    /// </summary>
    public required UsageCheck UsageCheck { get; set; }

    /// <summary>
    /// Some Plans, such as the Enterprise Plan, are unlimited, in which case this value is null.
    /// </summary>
    public required int? QuotaPerMonth { get; set; }

    /// <summary>
    /// The Free Plan is not allowed to exceed its quota. Other Plans are allowed to exceed their quota  for a certain
    /// price per unit.
    /// </summary>
    public required bool AllowedToExceed { get; set; }
}

public class UsageData : UsageQuota
{
    public required int UsageThisMonth { get; set; }
}
