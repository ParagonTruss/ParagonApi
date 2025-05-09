// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace ParagonApi.Models;

public class Point2D
{
    /// <summary>
    /// The X-coordinate, in inches.
    /// </summary>
    public required double X { get; set; }

    /// <summary>
    /// The Y-coordinate, in inches.
    /// </summary>
    public required double Y { get; set; }
}
