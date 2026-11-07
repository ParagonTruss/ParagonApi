namespace ParagonApi.Models;

/// <summary>
/// A combo lumber, as its species/grade pairs. "SP No.3 or SPF Stud" does not also permit SP Stud or SPF No.3.
/// </summary>
public class LumberCombo
{
    /// <summary>
    /// At least two pairs. <see cref="LumberSpecies.Combo"/> and <see cref="LumberGrade.Combo"/> are not allowed.
    /// </summary>
    public required List<TangibleLumber> ComboLumberPairs { get; set; }
}
