namespace ParagonApi.Models;

public class HangerPriceEdit
{
    public required Guid Guid { get; set; }
    public required StandardConnectingHardwareModel Hanger { get; set; }
    public required double Price { get; set; }
    public required string? Notes { get; set; }
}
