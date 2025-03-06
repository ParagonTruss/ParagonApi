namespace ParagonApi.Models;

public class BatchWithoutId
{
    public required Guid Guid { get; set; }
    public required Guid ProductionGroupGuid { get; set; }
}

public class Batch : BatchWithoutId
{
    /// <summary>
    /// The user-facing identifier for a batch. Unique to the organization, but not to the batch table.
    /// </summary>
    public required int Id { get; set; }
}
