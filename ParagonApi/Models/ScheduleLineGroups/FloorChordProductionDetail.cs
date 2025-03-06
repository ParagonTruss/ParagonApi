namespace ParagonApi.Models;

public class FloorChordProductionDetail(
    List<MemberProductionDetail> memberProductionDetailList,
    Dictionary<Guid, ProductionGroup> productionGroupDictionary
)
{
    public List<MemberProductionDetail> MemberProductionDetailList { get; set; } = memberProductionDetailList;
    public Dictionary<Guid, ProductionGroup> ProductionGroupDictionary { get; set; } = productionGroupDictionary;
}
