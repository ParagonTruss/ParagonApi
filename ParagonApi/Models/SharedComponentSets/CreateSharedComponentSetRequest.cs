namespace ParagonApi.Models;

public class CreateSharedComponentSetRequest
{
    public required string Name { get; set; }
    public required Guid SourceProjectGuid { get; set; }
}
