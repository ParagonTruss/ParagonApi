namespace ParagonApi.Models;

public class ScheduleLineGroupData
{
    public required ScheduleLineGroup ScheduleLineGroup { get; set; }
    public required Dictionary<
        Guid,
        List<ProductionComponentInstance>
    > OrderedProductionComponentInstancesByBundleGuid { get; set; }
    public required Dictionary<Guid, ProductionGroup> ProductionGroupsByGuid { get; set; }
    public required Dictionary<Guid, Batch> BatchesByGuid { get; set; }
    public required List<Bundle> OrderedBundles { get; set; }
}
