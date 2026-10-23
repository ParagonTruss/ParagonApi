namespace ParagonApi.Models;

public class NewPlatePrice
{
    /// <summary>
    /// Combo plate types are not supported.
    /// </summary>
    public required PlateType PlateType { get; set; }
    public required double PricePerPound { get; set; }
    public required string? Notes { get; set; }
}
