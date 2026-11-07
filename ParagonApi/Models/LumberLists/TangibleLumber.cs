namespace ParagonApi.Models;

/// <summary>
/// One species/grade pair of a combo lumber.
/// </summary>
public class TangibleLumber
{
    /// <summary>
    /// The lumber species. <see cref="LumberSpecies.Combo"/> is not allowed here.
    /// </summary>
    public required LumberSpecies Species { get; set; }

    /// <summary>
    /// The lumber grade. <see cref="LumberGrade.Combo"/> is not allowed here.
    /// </summary>
    public required LumberGrade Grade { get; set; }
}
