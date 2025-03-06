namespace ParagonApi.Models;

public class ProductionGroup
{
    public required Guid Guid { get; set; }
    public required Guid ProjectGuid { get; set; }
    public required string Organization { get; set; }
    public required string ProjectId { get; set; }

    /// <summary>
    /// This allows the user to specify a shorter version of the project name for use in printed artifacts, where
    /// space is limited.
    /// </summary>
    public required string ProjectShortName { get; set; }
    public required string BuildingType { get; set; }
    public required string BuildingInstance { get; set; }
    public required string Level { get; set; }
}
