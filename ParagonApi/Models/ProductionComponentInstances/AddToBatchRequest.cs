namespace ParagonApi.Models;

public class AddToBatchRequest
{
    public required Guid BatchGuid { get; set; }
    public required List<Guid> ProductionComponentInstanceGuids { get; set; }
}
