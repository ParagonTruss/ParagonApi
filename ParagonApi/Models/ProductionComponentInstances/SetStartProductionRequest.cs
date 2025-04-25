namespace ParagonApi.Models;

public class SetStartProductionRequest
{
    public required Guid ProductionComponentInstanceGuid { get; set; }
    public required Guid StationGuid { get; set; }
    public required DateTime StartProduction { get; set; }
    public required bool EnableOverwrite { get; set; }
}
