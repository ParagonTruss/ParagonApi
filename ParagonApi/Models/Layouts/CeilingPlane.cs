namespace ParagonApi.Models;

public class NewCeilingPlane
{
    public required PlaneReferenceGeometryType GeometryType { get; set; }
    public double Elevation { get; set; }
    public Segment2D? Segment { get; set; }
    public Guid BearingEnvelopeGuid { get; set; }
    public bool Flipped { get; set; }
    public required double Slope { get; set; }
    public List<PlaneCut> Cuts { get; set; } = [];
}

public class CeilingPlane : NewCeilingPlane
{
    public Guid Guid { get; set; }
}
