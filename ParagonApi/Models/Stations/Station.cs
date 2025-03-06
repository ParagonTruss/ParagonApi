namespace ParagonApi.Models;

// ReSharper disable once ClassNeverInstantiated.Global
public class StationComponentDesign
{
    public required int? Index { get; set; }
    public required int? Quantity { get; set; }
}

/// <summary>
/// A station either follows the schedule or has its own list of any component designs. This is demarcated by
/// <see cref="FollowsSchedule"/>. If that property is true, look to
/// <see cref="CurrentProductionComponentInstanceGuid"/> to know where the station is in the schedule.
/// Otherwise, refer to <see cref="ComponentDesigns"/> to know what components are at the station.
/// </summary>
public class Station
{
    public Guid Guid { get; set; } = Guid.NewGuid();
    public required string Organization { get; set; }
    public required string Name { get; set; }
    public required bool FollowsSchedule { get; set; }
    public required StationRole Role { get; set; }

    /// <summary>
    /// Only ever set if <see cref="FollowsSchedule"/> is true. Even then it may be empty if this has not been
    /// initialized.
    /// </summary>
    public required Guid? CurrentProductionComponentInstanceGuid { get; set; }

    public Dictionary<Guid, StationComponentDesign> ComponentDesigns { get; set; } =
        new Dictionary<Guid, StationComponentDesign>();
}

/// <summary>
/// Represents the primary function of a station, which is helpful in determining what information should be displayed
/// on load.
/// </summary>
public enum StationRole
{
    Assembly,
    ChordSaw,
    WebSaw,
    BlockSaw,
    PlatePull,
    Bundler,
}
