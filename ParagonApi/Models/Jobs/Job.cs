namespace ParagonApi.Models;

public class Job
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int NumberOfDesigns { get; set; }
    public required string Organization { get; set; }
    public required string Location { get; set; }
    public required string JobType { get; set; }
    public required string JobStatus { get; set; }
    public required string JobPriority { get; set; }
    public required DateTime Created { get; set; }
}
