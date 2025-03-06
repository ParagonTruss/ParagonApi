namespace ParagonApi.Models;

public class NewBearingEnvelope
{
    public required string Name { get; set; }
    public required Point2D LeftPoint { get; set; }
    public required Point2D RightPoint { get; set; }
    public required double Thickness { get; set; }
    public required double Top { get; set; }
    public required double Bottom { get; set; }
    public required Justification Justification { get; set; }
    public bool NonStructural { get; set; }
}

public class BearingEnvelope : NewBearingEnvelope
{
    public Guid Guid { get; set; }
}
