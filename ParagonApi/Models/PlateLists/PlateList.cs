namespace ParagonApi.Models;

public class NewPlateList
{
    public required string Name { get; set; }

    public bool IsArchived { get; set; }

    public required IList<PlateOption> Plates { get; set; }

    /// <summary>
    /// If true, the plate list is aggregated into ComboPlates.
    /// </summary>
    public bool UseComboPlates { get; set; }
}

public class PlateList : NewPlateList
{
    public required Guid Guid { get; set; }
}
