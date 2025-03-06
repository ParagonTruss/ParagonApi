// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace ParagonApi.Models;

public enum PlateOrientation
{
    FrontBack = 0,
    TopBottom = 1,
}

public class Plate
{
    public required Guid Guid { get; set; }

    public required string Name { get; set; }

    public required string Type { get; set; }

    public required Point2D Center { get; set; }

    public required double Length { get; set; }

    public required double Width { get; set; }

    public required PlateOrientation Orientation { get; set; }

    public required Direction3D SlotDirection { get; set; }

    public required Direction3D NormalDirection { get; set; }
}
