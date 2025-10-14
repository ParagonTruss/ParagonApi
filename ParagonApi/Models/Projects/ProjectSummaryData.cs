namespace ParagonApi.Models;

public class ProjectSummaryData
{
    public required int UniqueTrusses { get; set; }
    public required int TotalTrussesIncludingPlies { get; set; }

    public required double TotalActualBoardFeet { get; set; }
    public required double TotalStockBoardFeet { get; set; }

    /// <summary>
    /// Null if some prices are missing
    /// </summary>
    public required double? TotalPlateCost { get; set; }

    /// <summary>
    /// Null if some prices are missing
    /// </summary>
    public required double? TotalStockLumberCost { get; set; }

    /// <summary>
    /// Null if some prices are missing
    /// </summary>
    public required double? TotalHangersCost { get; set; }
}
