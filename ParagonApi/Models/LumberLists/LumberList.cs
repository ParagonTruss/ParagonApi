namespace ParagonApi.Models;

public class NewLumberList
{
    public required string Name { get; set; }

    public bool IsArchived { get; set; }

    public required IList<LumberSet> LumberSets { get; set; }
}

public class LumberList : NewLumberList
{
    public required Guid Guid { get; set; }
}
