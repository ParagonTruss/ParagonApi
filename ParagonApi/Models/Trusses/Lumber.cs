// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace ParagonApi.Models;

public enum LumberStructure
{
    Swan = 0,
    StructuralComposite = 1,
}

public class Lumber
{
    public required double ActualThickness { get; set; }
    public required double ActualWidth { get; set; }
    public double NominalWidth =>
        Structure == LumberStructure.StructuralComposite ? ActualWidth : InNominalInches(ActualWidth);

    public double NominalThickness =>
        Structure == LumberStructure.StructuralComposite ? ActualThickness : InNominalInches(ActualThickness);

    private static double InNominalInches(double actualInches)
    {
        if (actualInches >= 6.25)
        {
            return actualInches + .75;
        }
        if (actualInches >= 1.49 && actualInches < 6.25)
        {
            return actualInches + .5;
        }
        //less than 1.49
        return actualInches + .25;
    }

    public required string Grade { get; set; }
    public required string Species { get; set; }
    public required LumberStructure Structure { get; set; }
    public required string TreatmentType { get; set; }
}
