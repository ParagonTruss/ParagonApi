namespace ParagonApi.Models;

public class NewLumberPrice
{
    public required double PricePerThousandBoardFeet { get; set; }

    /// <summary>
    /// The nominal thickness, e.g. the 2 in 2x4.
    /// </summary>
    public required double NominalThicknessInInches { get; set; }

    /// <summary>
    /// The nominal width, e.g. the 4 in 2x4.
    /// </summary>
    public required double NominalWidthInInches { get; set; }

    public required double LengthInInches { get; set; }
    public required LumberGrade Grade { get; set; }
    public required LumberSpecies Species { get; set; }
    public required LumberTreatmentType TreatmentType { get; set; }
    public required string? Notes { get; set; }
}
