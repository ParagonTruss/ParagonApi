namespace ParagonApi.Models;

public class UpdateAssemblyGroupShallowRequest
{
    public required string Name { get; set; }
    public required string? Notes { get; set; }
    public required bool Archived { get; set; }
}
