namespace ParagonApi.Models;

public class SendToStationRequest
{
    public Guid StationGuid { get; set; }
    public bool ClearStation { get; set; }
}
