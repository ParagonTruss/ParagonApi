namespace ParagonApi.Models;

/// <summary>
/// Identify a set of components by a lookup code.
/// </summary>
public class SharedComponentSet
{
    public required string LookupCode { get; set; }
    public required string Organization { get; set; }
    public required Guid? SourceProjectGuid { get; set; }
    public required Guid? ProjectSnapshotGuid { get; set; }
    public required string Name { get; set; }
    public required List<AnalysisSetGuidWithQuantity> AnalysisSetGuidsWithQuantities { get; set; }
    public required DateTimeOffset Created { get; set; }
    public required string ContactEmail { get; set; }
    public required string ContactName { get; set; }
    public required string ContactPhone { get; set; }
}

public class AnalysisSetGuidWithQuantity
{
    public required Guid AnalysisSetGuid { get; set; }
    public required int Quantity { get; set; }
}
