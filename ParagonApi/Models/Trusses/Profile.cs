namespace ParagonApi.Models;

public class Profile
{
    public required string Name { get; set; }
    public required List<Point2D> TopChordPoints { get; set; }
    public required List<Point2D> BottomChordPoints { get; set; }
    public required Overhang LeftOverhang { get; set; }
    public required Overhang RightOverhang { get; set; }
}
