namespace ParagonApi.Models.AnalogModels;

public class AnalogJoint
{
    public required Guid Guid { get; set; }
    public required string Name { get; set; }
    public required Point2D Location { get; set; }
    public required BoundaryType BoundaryType { get; set; }
}
