namespace ParagonApi.Models;

public class AppendToBundleRequest
{
    public required Guid BundleGuid { get; set; }
    public required Dictionary<Guid, Point2D> InstancePositions { get; set; }
}
