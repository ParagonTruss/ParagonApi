namespace ParagonApi.Models;

public class OrderStationComponentDesignRequest
{
    /// <summary>
    /// This list must contain all the components in the station.
    /// </summary>
    public required List<Guid> OrderedStationComponentDesigns { get; set; }
}
