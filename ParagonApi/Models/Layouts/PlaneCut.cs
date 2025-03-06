namespace ParagonApi.Models;

public enum PlaneCutType
{
    AbsoluteVertical,
    AgainstPlane,
}

public class PlaneCut
{
    public required PlaneCutType Type { get; set; }
    public Guid CuttingPlaneGuid { get; set; }
    public Segment2D? Segment { get; set; }
}
