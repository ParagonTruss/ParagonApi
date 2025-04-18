namespace ParagonApi.Models;

public class Point3D
{
    /// <summary>
    /// The X-coordinate, in inches.
    /// </summary>
    public required double X { get; set; }

    /// <summary>
    /// The Y-coordinate, in inches.
    /// </summary>
    public required double Y { get; set; }

    /// <summary>
    /// The Z-coordinate, in inches.
    /// </summary>
    public required double Z { get; set; }
}
