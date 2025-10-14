namespace ParagonApi.Models
{
    public class AssemblyGroup
    {
        public required Guid Guid { get; set; }
        public required string Name { get; set; }
        public required string Organization { get; set; }
        public required DateTimeOffset Created { get; set; }
        public required Dictionary<Guid, StationComponentDesign> ComponentDesigns { get; set; }
        public required string? Notes { get; set; }
        public required bool Archived { get; set; }
    }
}
