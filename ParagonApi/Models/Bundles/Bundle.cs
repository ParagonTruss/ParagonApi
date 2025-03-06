namespace ParagonApi.Models;

public class BundleWithoutId
{
    public required Guid Guid { get; set; }
    public required Guid ProductionGroupGuid { get; set; }
    public required Guid? ScheduleGroupGuid { get; set; }
    public required Guid? ScheduleLineGroupGuid { get; set; }
    public required int? ScheduleLineGroupPriority { get; set; }
    public required Guid? TruckloadGuid { get; set; }
}

public class Bundle : BundleWithoutId
{
    /// <summary>
    /// The user-facing identifier for a bundle. Unique to the organization, but not to the bundle table.
    /// </summary>
    public required int Id { get; set; }
}
