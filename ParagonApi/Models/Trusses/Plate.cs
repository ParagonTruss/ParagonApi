// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace ParagonApi.Models;

public enum PlateOrientation
{
    FrontBack = 0,
    TopBottom = 1,
}

public enum PlateGeometryType
{
    Rectangular = 0,
    TPlate = 1,

    /// <summary>
    /// The left-handed bevel plate variant generally occurs on the left side of a truss viewed on a TDD. It is a
    /// rectangle sliced at a 45-degree angle through the top right point when viewed unrotated.
    /// </summary>
    BevelPlateLeftHanded = 2,

    /// <summary>
    /// The right-handed bevel plate variant generally occurs on the right side of a truss viewed on a TDD. It is a
    /// rectangle sliced at a 45-degree angle through the bottom right point when viewed unrotated.
    /// </summary>
    BevelPlateRightHanded = 3,
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

    public PlateGeometryType GeometryType { get; set; }
}
