namespace ParagonApi.Models;

public class LayoutFace
{
    public required List<Point3D> VertexLoop { get; set; }

    public double Overhang { get; set; } = 0;
}
