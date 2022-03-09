namespace StructuralMechanics.Models
{
    public abstract class VectorPhysicalQuantity
    {
        public int Id { get; set; }
        public double Magnitude { get; set; }
        public Direction Direction { get; set; }
        public VectorType VectorType { get; set; }

        //Navigation Properties
        public Project Project { get; set; }


        public VectorPhysicalQuantity(double magnitude, Direction direction)
        {
            this.Magnitude = magnitude;
            this.Direction = direction;
        }
    }
}
