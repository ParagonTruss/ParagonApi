namespace ParagonApi.Connections;

public class ScheduleLineGroupsConnection(HttpClient designServiceClient)
{
    private HttpClient Client { get; } = designServiceClient;

    public Task<List<ScheduleLineGroup>> GetActiveScheduleLineGroupsByStation(Guid stationGuid) =>
        Client.Get<List<ScheduleLineGroup>>(
            $"/api/public/scheduleLineGroups/getActiveScheduleLineGroupsByStation/{stationGuid}"
        );

    public Task<ScheduleLineGroupData> GetScheduleLineGroupData(Guid scheduleLineGroupGuid) =>
        Client.Get<ScheduleLineGroupData>(
            $"api/public/scheduleLineGroups/{scheduleLineGroupGuid}/getScheduleLineGroupData"
        );

    public Task<FloorChordProductionDetail> GetFloorChordMemberProductionDetail(Guid scheduleLineGroupGuid) =>
        Client.Get<FloorChordProductionDetail>(
            $"/api/public/scheduleLineGroups/{scheduleLineGroupGuid}/getFloorChordMemberProductionDetail"
        );
}
