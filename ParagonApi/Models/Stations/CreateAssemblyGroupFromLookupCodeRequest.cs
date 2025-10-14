namespace ParagonApi.Models;

public class CreateAssemblyGroupFromLookupCodeRequest
{
    public required string Name { get; set; }
    public required string? Notes { get; set; }
    public required string SharedComponentSetLookupCode { get; set; }
}
