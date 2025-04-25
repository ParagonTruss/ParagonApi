namespace ParagonApi.Models;

public class ParseComponentsFromBatchRequest
{
    public required string BatchName { get; set; }
    public required Base64File CntFile { get; set; }
}
