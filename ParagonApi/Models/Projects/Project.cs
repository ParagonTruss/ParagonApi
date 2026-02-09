namespace ParagonApi.Models;

public class ProjectBase
{
    public required string Name { get; set; }

    public string? Region { get; set; }
    public string? DesignProgram { get; set; }
    public string? CustomerName { get; set; }
    public string? LotNumber { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Subdivision { get; set; }
    public string? Model { get; set; }
    public string? BuildingDesignerName { get; set; }
    public string? BuildingDesignerAddress { get; set; }
    public string? BuildingDesignerCity { get; set; }
    public string? BuildingDesignerState { get; set; }
    public string? BuildingDesignerLicenseNumber { get; set; }
    public string? ProjectSalesman { get; set; }
}

public class NewProject : ProjectBase
{
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
}

public class Project : ProjectBase
{
    public required Guid Guid { get; set; }
    public required List<Guid> ComponentDesignGuids { get; set; }

    public required string ContactName { get; set; }
    public required string ContactPhone { get; set; }
    public required string ContactEmail { get; set; }
}
