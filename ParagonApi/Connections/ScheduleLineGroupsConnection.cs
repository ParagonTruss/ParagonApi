namespace ParagonApi.Connections;

public class ScheduleLineGroupsConnection
{
    private HttpClient Client { get; }

    public ScheduleLineGroupsConnection(HttpClient designServiceClient)
    {
        Client = designServiceClient;
    }

    public async Task<List<ScheduleLineGroup>> GetActiveScheduleLineGroupsByStation(Guid stationGuid)
    {
        var url = $"/api/public/scheduleLineGroups/getActiveScheduleLineGroupsByStation/{stationGuid}";
        var response = await Client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<List<ScheduleLineGroup>>(responseContent);
    }

    public async Task<ScheduleLineGroupData> GetScheduleLineGroupData(Guid scheduleLineGroupGuid)
    {
        var response = await Client.GetAsync(
            $"api/public/scheduleLineGroups/{scheduleLineGroupGuid}/getScheduleLineGroupData"
        );

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<ScheduleLineGroupData>(content);
    }

    public async Task<FloorChordProductionDetail> GetFloorChordMemberProductionDetail(Guid scheduleLineGroupGuid)
    {
        var url = $"/api/public/scheduleLineGroups/{scheduleLineGroupGuid}/getFloorChordMemberProductionDetail";
        var response = await Client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<FloorChordProductionDetail>(responseContent);
    }
}
