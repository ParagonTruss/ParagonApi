namespace ParagonApi.Models;

public enum OverhangCutType
{
    Plumb,
    Square,
    Horizontal,
}

public class Overhang
{
    public required double Distance { get; set; }
    public OverhangCutType CutType { get; set; } = OverhangCutType.Plumb;
}
