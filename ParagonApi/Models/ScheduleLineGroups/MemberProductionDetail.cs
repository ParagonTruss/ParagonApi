namespace ParagonApi.Models;

public class MemberProductionDetail(
    Guid? trussGuid,
    Guid? productionComponentInstanceGuid,
    Guid? productionGroupGuid,
    string trussName,
    string pieceId,
    string chordName,
    double lengthInInches,
    string lumber,
    string stockLength,
    int plySequence,
    int plies,
    int componentGroupSequence,
    int componentGroupQuantity,
    string batchId,
    string bundleId
)
{
    public Guid? TrussGuid { get; } = trussGuid;
    public Guid? ProductionComponentInstanceGuid { get; } = productionComponentInstanceGuid;
    public Guid? ProductionGroupGuid { get; } = productionGroupGuid;
    public string TrussName { get; } = trussName;
    public string PieceId { get; } = pieceId;
    public string ChordName { get; } = chordName;
    public double LengthInInches { get; } = lengthInInches;
    public string Lumber { get; } = lumber;
    public int PlySequence { get; } = plySequence;
    public int Plies { get; } = plies;
    public int ComponentGroupSequence { get; } = componentGroupSequence;
    public int ComponentGroupQuantity { get; } = componentGroupQuantity;
    public string StockLength { get; } = stockLength;
    public string BatchId { get; } = batchId;
    public string BundleId { get; } = bundleId;
}
