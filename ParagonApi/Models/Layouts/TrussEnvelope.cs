namespace ParagonApi.Models;

public class NewTrussEnvelope
{
    public required string Name { get; set; }
    public required Point2D LeftPoint { get; set; }
    public required Point2D RightPoint { get; set; }
    public required double Elevation { get; set; }
    public required Justification Justification { get; set; }
    public required double Thickness { get; set; }
    public required double LeftOverhang { get; set; }
    public required double RightOverhang { get; set; }
    public BevelCut? LeftBevelCut { get; set; }
    public BevelCut? RightBevelCut { get; set; }
    public Guid? RoofContainerGuid { get; set; }
    public List<TopOrBottomCut> TopCuts { get; set; } = [];
    public List<TopOrBottomCut> BottomCuts { get; set; } = [];
}

public class TrussEnvelope : NewTrussEnvelope
{
    public Guid Guid { get; set; }
    public required Guid? ComponentDesignGuid { get; set; }
}

public enum BevelCutType
{
    Back,
    Double,
    Front,
}

public class BevelCut
{
    public required BevelCutType Type { get; set; }
    public required double Angle { get; set; }
}

public enum TopOrBottomCutType
{
    Absolute,
    RoofPlane,
    CeilingPlane,
}

public class TopOrBottomCut
{
    public required TopOrBottomCutType Type { get; set; }
    public Plane3D? Plane { get; set; }
    public Guid RoofPlaneGuid { get; set; }
    public Guid CeilingPlaneGuid { get; set; }
}
