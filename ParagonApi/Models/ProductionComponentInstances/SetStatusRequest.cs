namespace ParagonApi.Models;

public class SetStatusRequest
{
    public required List<Guid> ProductionComponentInstanceGuids { get; set; }
    public required ProductionComponentInstanceStatus Status { get; set; }
}
