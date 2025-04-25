namespace ParagonApi.Models.AnalogModels;

public class AnalogLink
{
    public required Guid Guid { get; set; }
    public required Guid IJointGuid { get; set; }
    public required Guid JJointGuid { get; set; }
    public required double IFixity { get; set; }
    public required double JFixity { get; set; }
}
