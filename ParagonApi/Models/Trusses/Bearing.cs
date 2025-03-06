// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace ParagonApi.Models;

public class Bearing
{
    public required Guid Guid { get; set; }

    public required Segment2D Geometry { get; set; }
}
