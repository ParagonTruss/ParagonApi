namespace ParagonApi.Models;

public class ScheduleLineGroup
{
    public required Guid Guid { get; set; }

    public required string Name { get; set; }

    /// <summary>
    /// Should a <see cref="ScheduleLineGroup"/> not be associated with any bundles, it should still be associated
    /// with an organization.
    /// </summary>
    public required string Organization { get; set; }

    public required Guid LineGuid { get; set; }

    /// <summary>
    /// The priority of this <see cref="ScheduleLineGroup"/>, used to compare to other
    /// <see cref="ScheduleLineGroup"/> priorities.
    /// </summary>
    public required int Priority { get; set; }

    /// <summary>
    /// Optionally set a date for production for the <see cref="ScheduleLineGroup"/>. For organizations that just
    /// want a ranked list (like Clearspan), this field will go unused.
    /// </summary>
    public required DateTime? ScheduledDate { get; set; } // TODO change to DateOnly in C# 10
}
