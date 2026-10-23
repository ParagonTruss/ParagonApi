namespace ParagonApi.Models;

public class PlatePriceEdit
{
    public required Guid Guid { get; set; }
    public required double PricePerPound { get; set; }
    public required string? Notes { get; set; }
}
