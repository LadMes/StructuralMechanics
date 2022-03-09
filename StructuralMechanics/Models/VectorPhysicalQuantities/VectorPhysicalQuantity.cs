namespace StructuralMechanics.Models
{
    public abstract class VectorPhysicalQuantity
    {
        public int VectorPhysicalQuantityId { get; set; }
        public Guid ProjectId { get; set; }
        public double Magnitude { get; set; }
        public Direction Direction { get; set; }
        public VectorType VectorType { get; set; }

        //public VectorPhysicalQuantity() { }

        public VectorPhysicalQuantity(double magnitude, Direction direction)
        {
            this.Magnitude = magnitude;
            this.Direction = direction;
        }
    }
}
