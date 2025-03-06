// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace ParagonApi.Models;

public class Truss
{
    public required Guid Guid { get; set; }

    public required string Name { get; set; }
    public required int Plies { get; set; }

    public required List<Member> Members { get; set; }
    public required List<Plate> Plates { get; set; }
    public required List<Bearing> Bearings { get; set; }

    public double OutsideToOutsideBearingSpan
    {
        get
        {
            var bearingXs = Bearings
                .SelectMany(bearing => new List<Point2D> { bearing.Geometry.BasePoint, bearing.Geometry.EndPoint })
                .Select(point => point.X)
                .ToList();
            if (!bearingXs.Any())
                return 0;
            var minX = bearingXs.Min();
            var maxX = bearingXs.Max();
            return maxX - minX;
        }
    }

    /// <summary>
    /// Returns the overall height of this component, from the lowest member y point to the highest member y point
    /// </summary>
    public double Height
    {
        get
        {
            var allPoints = Members.SelectMany(member => member.Geometry).ToList();

            var smallestY = allPoints.Min(point => point.Y);
            var largestY = allPoints.Max(point => point.Y);

            return largestY - smallestY;
        }
    }

    /// <summary>
    /// Returns the overall width of this component, from the smallest member x point to the largest member x point
    /// </summary>
    public double Width
    {
        get
        {
            var allPoints = Members.SelectMany(member => member.Geometry).ToList();

            var smallestX = allPoints.Min(point => point.X);
            var largestX = allPoints.Max(point => point.X);

            return largestX - smallestX;
        }
    }
}
