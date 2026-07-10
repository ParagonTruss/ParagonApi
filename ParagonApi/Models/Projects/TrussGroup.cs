namespace ParagonApi.Models;

public class NewTrussGroup
{
    public required Guid? ParentGuid { get; set; }
    public required string Name { get; set; }
    public required List<Guid> TrussEnvelopeGuids { get; set; }
}

public class TrussGroup : NewTrussGroup
{
    public required Guid Guid { get; set; }
}
