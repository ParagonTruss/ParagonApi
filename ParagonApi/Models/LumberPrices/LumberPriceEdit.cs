namespace ParagonApi.Models;

/// <summary>
/// Only the price and notes of a lumber price can be changed; the lumber and length it prices cannot.
/// </summary>
public class LumberPriceEdit
{
    public required Guid Guid { get; set; }
    public required double PricePerThousandBoardFeet { get; set; }
    public required string? Notes { get; set; }
}
