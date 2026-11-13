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

    /// <summary>
    /// When `true`, the cut runs along the whole line through <see cref="Segment"/> instead of stopping at its ends.
    /// Only used when <see cref="Type"/> is <see cref="PlaneCutType.AbsoluteVertical"/>.
    /// </summary>
    public bool IsInfinite { get; set; }
}
