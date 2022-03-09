namespace StructuralMechanics.Models
{
    public abstract class ShapeSharedInfo : Geometry
    {
        public double FirstMomentOfArea { get; set; }
        public double SecondMomentOfArea { get; set; }
    }
}
