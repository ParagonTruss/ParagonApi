namespace ParagonApi.Models;

public class CreateAssemblyGroupRequest
{
    public required string Name { get; set; }
    public required string? Notes { get; set; }
    public required Dictionary<Guid, StationComponentDesign> ComponentDesigns { get; set; }
}
