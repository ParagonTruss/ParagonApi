namespace ParagonApi.Models;

public enum ProductionComponentInstanceStatus
{
    Unscheduled,
    Scheduled,
    StartedAssembly,
    FinishedAssembly,
    StoredOnYard,
    Shipped,
    Delivered,
}

public class ProductionComponentInstance
{
    public required Guid Guid { get; set; }

    // TODO Remove this after migrating PlatePicker and FITA Saw apps to use `Guid` instead of `InstanceGuid`
    [Obsolete("Use Guid instead")]
    public Guid InstanceGuid => Guid;
    public required Guid AnalysisSetGuid { get; set; }
    public required Guid ProductionGroupGuid { get; set; }
    public required Guid? BatchGuid { get; set; }
    public required Guid? BundleGuid { get; set; }

    /// <summary>
    /// Looking at the bundle top-down, this is the absolute position of this instance in inches.
    /// </summary>
    public required double? BundlePositionX { get; set; }
    public required double? BundlePositionY { get; set; }

    public required Guid? RebuildOf { get; set; }
    public required ProductionComponentInstanceStatus Status { get; set; }
}
