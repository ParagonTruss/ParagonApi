namespace ParagonApi.Models;

public class NewHangerPrice
{
    public required StandardConnectingHardwareModel Hanger { get; set; }
    public required double Price { get; set; }
    public required string? Notes { get; set; }
}
