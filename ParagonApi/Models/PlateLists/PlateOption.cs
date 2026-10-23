namespace ParagonApi.Models;

public class PlateOption
{
    /// <summary>
    /// The plate type, e.g. MT20.
    /// </summary>
    public required PlateType PlateType { get; set; }

    /// <summary>
    /// The tangible plate types aggregated by a combo plate type. Empty for tangible plate types.
    /// </summary>
    public List<PlateType> TangiblePlateTypesForComboPlateType { get; set; } = [];

    /// <summary>
    /// The width of the plate in inches.
    /// </summary>
    public required double Width { get; set; }

    /// <summary>
    /// The length of the plate in inches.
    /// </summary>
    public required double Length { get; set; }

    public PlateGeometryType GeometryType { get; set; }
}
