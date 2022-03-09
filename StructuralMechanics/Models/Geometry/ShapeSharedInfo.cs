namespace StructuralMechanics.Models
{
    public abstract class ShapeSharedInfo : GeometryObject
    {
        public double FirstMomentOfArea { get; set; }
        public double SecondMomentOfArea { get; set; }
    }
}
