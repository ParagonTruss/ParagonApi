namespace ParagonApi.Models;

/// <summary>
/// The types of members which can be included in cut sheets.
/// </summary>
public enum CutSheetMemberType
{
    Chord,
    Web,
    Block,
    Other,
}

public class ShopDrawingOptions
{
    public required bool IncludeComponentSchematics { get; set; }

    public required bool IncludeCutSheets { get; set; }

    /// <summary>
    /// Combine the cut sheets for all components into shared pages, rather than making a cut sheet per component.
    /// </summary>
    public required bool CombineCutSheets { get; set; }

    public required bool PortraitOrientation { get; set; }

    /// <summary>
    /// Put a component's cuts on the same page as its component schematic. Only applicable if
    /// <see cref="PortraitOrientation"/> is true.
    /// </summary>
    public required bool CutsOnSamePage { get; set; }

    public required DistanceFormat DistanceFormat { get; set; }

    /// <summary>
    /// If true, square cuts are labeled as 0 degrees; otherwise they are labeled as 90 degrees.
    /// </summary>
    public required bool SquareCutAngleIsZero { get; set; }

    /// <summary>
    /// Shop drawings may be generated for different saws which are interested in different sets of members. If
    /// <see cref="CutSheetMemberType.Block"/> is included here, any non-chord member with only right angle cuts is
    /// considered a block and will be put in the blocks section.
    /// </summary>
    public required List<CutSheetMemberType> IncludedMemberTypes { get; set; }
}

/// <summary>
/// Like <see cref="ShopDrawingOptions"/>, but the properties which have counterparts in organization settings are
/// optional; any that are not provided default to the requesting user's organization settings.
/// </summary>
public class ShopDrawingOptionsRequest
{
    public required bool IncludeComponentSchematics { get; set; }

    public required bool IncludeCutSheets { get; set; }

    /// <summary>
    /// Combine the cut sheets for all components into shared pages, rather than making a cut sheet per component.
    /// </summary>
    public required bool CombineCutSheets { get; set; }

    /// <summary>
    /// If not provided, defaults to the organization setting.
    /// </summary>
    public bool? PortraitOrientation { get; set; }

    /// <summary>
    /// Put a component's cuts on the same page as its component schematic. Only applicable if
    /// <see cref="PortraitOrientation"/> is true.
    /// </summary>
    public required bool CutsOnSamePage { get; set; }

    /// <summary>
    /// If not provided, defaults to the organization setting.
    /// </summary>
    public DistanceFormat? DistanceFormat { get; set; }

    /// <summary>
    /// If true, square cuts are labeled as 0 degrees; otherwise they are labeled as 90 degrees. If not provided,
    /// defaults to the organization setting.
    /// </summary>
    public bool? SquareCutAngleIsZero { get; set; }

    /// <summary>
    /// Shop drawings may be generated for different saws which are interested in different sets of members. If
    /// <see cref="CutSheetMemberType.Block"/> is included here, any non-chord member with only right angle cuts is
    /// considered a block and will be put in the blocks section.
    /// </summary>
    public required List<CutSheetMemberType> IncludedMemberTypes { get; set; }
}
