namespace ParagonApi.Models;

public enum PlaneReferenceGeometryType
{
    Absolute,
    BearingEnvelope,
}

public class NewRoofPlane
{
    public required PlaneReferenceGeometryType GeometryType { get; set; }
    public double Elevation { get; set; }
    public Segment2D? Segment { get; set; }

    /// <summary>
    /// When `true`, the base line runs along the whole line through <see cref="Segment"/> instead of stopping at its
    /// ends. Only used when <see cref="GeometryType"/> is <see cref="PlaneReferenceGeometryType.Absolute"/>.
    /// </summary>
    public bool IsInfinite { get; set; }

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
