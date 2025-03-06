// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace ParagonApi.Models;

public class Member
{
    public required Guid Guid { get; set; }
    public required string Name { get; set; }
    public required string AssemblyName { get; set; }
    public required string Type { get; set; }

    public required Lumber Lumber { get; set; }

    public required List<Point2D> Geometry { get; set; }

    public required double Thickness { get; set; }
    public required double OverallLength { get; set; }

    public required List<Plane3D> BevelCuts { get; set; }
}
