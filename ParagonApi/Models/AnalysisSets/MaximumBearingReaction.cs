namespace ParagonApi.Models;

public class MaximumBearingReaction
{
    public required Point2D JointLocation { get; set; }
    public required double? UpForce { get; set; }
    public required double? DownForce { get; set; }
}
