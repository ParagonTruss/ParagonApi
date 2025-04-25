namespace ParagonApi.Models;

public class SetEndProductionRequest
{
    public required Guid ProductionComponentInstanceGuid { get; set; }
    public required Guid StationGuid { get; set; }
    public required DateTime EndProduction { get; set; }
    public required bool EnableOverwrite { get; set; }
}
