namespace ParagonApi.Models;

public class PlatePrice
{
    public required Guid Guid { get; set; }
    public required string Organization { get; set; }
    public required string Location { get; set; }
    public required double PricePerPound { get; set; }
    public required PlateType PlateType { get; set; }
    public required DateTime PriceDateTime { get; set; }
    public required string? Notes { get; set; }
}
