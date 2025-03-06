namespace ParagonApi.Models;

public class NewProject
{
    public required string Name { get; set; }
}

public class Project : NewProject
{
    public Guid Guid { get; set; }
}
