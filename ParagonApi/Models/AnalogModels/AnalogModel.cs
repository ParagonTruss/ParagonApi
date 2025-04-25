namespace ParagonApi.Models.AnalogModels;

public class AnalogModel
{
    public required Guid Guid { get; set; }
    public required List<AnalogJoint> Joints { get; set; }
    public required List<AnalogLink> Links { get; set; }
}
