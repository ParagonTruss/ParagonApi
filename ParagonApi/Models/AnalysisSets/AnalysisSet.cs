namespace ParagonApi.Models;

public class AnalysisSet
{
    public required Guid Guid { get; set; }
    public required decimal CapacityRatio { get; set; }
    public required List<MaximumBearingReaction> MaximumBearingReactions { get; set; }
    public required double? RequiredSlopedTopChordPurlinSpacing { get; set; }
    public required double? RequiredFlatTopChordPurlinSpacing { get; set; }
    public required double? RequiredBottomChordPurlinSpacing { get; set; }
}
