namespace ParagonApi.Models;

/// <summary>
/// Represents the face of a solid.
/// </summary>
public class SolidDataFace
{
    /// <summary>
    /// Each element is an index into <see cref="SolidData.Vertices"/> for that face's outer bounds. The vertices are
    /// assumed to be oriented counter-clockwise with the face's normal pointing towards the exterior of the solid.
    /// </summary>
    public required List<int> Outer { get; set; }

    /// <summary>
    /// Each element is a list of vertex indices indexing into <see cref="SolidData.Vertices"/> for that face's inner
    /// bounds. For a face with no holes, this should be an empty list. Each list of vertices is assumed to be oriented
    /// counter-clockwise with their normal pointing towards the interior of the solid.
    /// </summary>
    public List<List<int>> Inner { get; set; } = [];
}

/// <summary>
/// Represents a solid.
/// </summary>
public class SolidData
{
    /// <summary>
    /// The vertices for this solid.
    /// </summary>
    public required List<Point3D> Vertices { get; set; }

    /// <summary>
    /// The faces for this solid.
    /// </summary>
    public required List<SolidDataFace> Faces { get; set; }
}

/// <summary>
/// A roof container defines the outer shape of a part of a roof.
/// </summary>
public class NewRoofContainer
{
    /// <summary>
    /// The human-readable ID of a roof container. This should typically be unique, but is not guaranteed to be.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The roof solid. This does not include overhangs.
    /// </summary>
    public required SolidData SolidData { get; set; }
}

/// <summary>
/// A roof container defines the outer shape of a part of a roof.
/// </summary>
public class RoofContainer : NewRoofContainer
{
    /// <summary>
    /// Unique ID
    /// </summary>
    public Guid Guid { get; set; }
}
