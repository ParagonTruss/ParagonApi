namespace ParagonApi.Models;

/// <summary>
/// The material price of a single truss, broken out by material type.  Each price is only reported when every
///   material of that kind has a price; if any is missing, that price is null and the materials which are missing
///   prices are listed by name.  The other prices are still reported.
/// </summary>
public class TrussPrice
{
    public required Guid TrussGuid { get; set; }

    /// <summary>
    /// Null if any plate price is missing
    /// </summary>
    public required double? PlatePrice { get; set; }

    /// <summary>
    /// Null if any lumber price is missing
    /// </summary>
    public required double? LumberPrice { get; set; }

    /// <summary>
    /// Null if any hanger price is missing
    /// </summary>
    public required double? HangerPrice { get; set; }

    /// <summary>
    /// The plate types which are missing a price
    /// </summary>
    public required List<string> PlatesMissingPrices { get; set; }

    /// <summary>
    /// The lumber which is missing a price, by lumber abbreviation
    /// </summary>
    public required List<string> LumberMissingPrices { get; set; }

    /// <summary>
    /// The hangers which are missing a price, by hanger name
    /// </summary>
    public required List<string> HangersMissingPrices { get; set; }
}
