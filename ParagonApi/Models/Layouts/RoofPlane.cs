namespace ParagonApi.Models;

public enum RoofPlaneReferenceGeometryType
{
    Absolute,
    BearingEnvelope,
}

public class NewRoofPlane
{
    public required RoofPlaneReferenceGeometryType GeometryType { get; set; }
    public double Elevation { get; set; }
    public Segment2D? Segment { get; set; }
    public Guid BearingEnvelopeGuid { get; set; }
    public bool Flipped { get; set; }
    public required double Slope { get; set; }
    public required double HeelHeight { get; set; }
    public required double Overhang { get; set; }
    public double Cantilever { get; set; }
    public List<PlaneCut> Cuts { get; set; } = [];
}

public class RoofPlane : NewRoofPlane
{
    public Guid Guid { get; set; }
}
