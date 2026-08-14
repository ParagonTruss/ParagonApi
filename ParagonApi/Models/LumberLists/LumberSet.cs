namespace ParagonApi.Models;

/// <summary>
/// Specifies lumber properties that are enumerated in every combination with each other.
/// </summary>
public class LumberSet
{
    /// <summary>
    /// Identifies this lumber set within its lumber list. Leave unset when adding a new lumber set and one will be
    /// assigned.
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// The lumber species. <see cref="LumberSpecies.Combo"/> is not allowed here; use
    /// <see cref="ComboSpecies"/> instead.
    /// </summary>
    public required List<LumberSpecies> Species { get; set; }

    /// <summary>
    /// Each entry is a list of lumber species aggregated into a combo species.
    /// </summary>
    public List<List<LumberSpecies>> ComboSpecies { get; set; } = [];

    /// <summary>
    /// The lumber grades. <see cref="LumberGrade.Combo"/> is not allowed here; use <see cref="ComboGrades"/>
    /// instead.
    /// </summary>
    public required List<LumberGrade> Grades { get; set; }

    /// <summary>
    /// Each entry is a list of lumber grades aggregated into a combo grade.
    /// </summary>
    public List<List<LumberGrade>> ComboGrades { get; set; } = [];

    /// <summary>
    /// The lumber treatment types.
    /// </summary>
    public required List<LumberTreatmentType> TreatmentTypes { get; set; }

    /// <summary>
    /// The actual (not nominal) first cross-section dimensions in inches.
    /// </summary>
    public required List<double> ActualDimensions1 { get; set; }

    /// <summary>
    /// The actual (not nominal) second cross-section dimensions in inches.
    /// </summary>
    public required List<double> ActualDimensions2 { get; set; }

    /// <summary>
    /// The stock lengths in inches.
    /// </summary>
    public required List<double> StockLengths { get; set; }
}
