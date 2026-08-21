namespace ParagonApi.Models;

public class HangerPrice
{
    public required Guid Guid { get; set; }
    public required string Organization { get; set; }
    public required string Location { get; set; }
    public required double Price { get; set; }
    public required StandardConnectingHardwareModel Hanger { get; set; }
    public required DateTime PriceDateTime { get; set; }
    public required string? Notes { get; set; }
}
