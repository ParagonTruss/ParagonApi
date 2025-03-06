namespace ParagonApi.Models;

public class ProductionComponentInstanceBuildLog
{
    public required Guid InstanceGuid { get; set; }
    public required Guid StationGuid { get; set; }
    public required DateTime StartProduction { get; set; }
    public required DateTime? EndProduction { get; set; }
}
