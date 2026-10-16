namespace ParagonApi.Models;

/// <summary>
/// How many copies of a truss a project contains, whether they were added in Design or placed in a layout.
/// </summary>
public class TrussQuantity
{
    /// <summary>
    /// The truss's GUID: one of the project's <c>ComponentDesignGuids</c>, and the <c>Guid</c> of the truss
    /// returned by <c>GET trusses/{guid}</c>.
    /// </summary>
    public required Guid ComponentDesignGuid { get; set; }

    /// <summary>
    /// Counts each copy of a multi-ply truss once, not once per ply. Multiply by the truss's <c>Plies</c> to count
    /// plies.
    /// </summary>
    public required int Quantity { get; set; }
}
