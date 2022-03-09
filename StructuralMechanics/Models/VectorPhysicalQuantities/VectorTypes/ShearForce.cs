namespace StructuralMechanics.Models
{
    public class ShearForce : VectorPhysicalQuantity
    {
        //Navigation Properties
        public Point Location { get; set; }


        public ShearForce(double magnitude, Direction direction, Point location) : base(magnitude, direction)
        {
            this.Location = location;
            this.VectorType = VectorType.ShearForce;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            else
            {
                ShearForce shearForceToCompare = (ShearForce)obj;

                return (this.Magnitude == shearForceToCompare.Magnitude) && (this.Location.X == shearForceToCompare.Location.X);
            }
        }

        public override int GetHashCode()
        {
            return this.Magnitude.GetHashCode() ^ this.Location.X.GetHashCode();
        }

        public override string ToString()
        {
            return $"Q = {this.Magnitude} N" +
                $"The location from the coordinate origin (x coordinate): {this.Location.X} mm" +
                $"Force direction: {this.Direction}";
        }
    }
}
