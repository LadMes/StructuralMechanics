using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public class ShearForce : VectorPhysicalQuantity
    {
        //Navigation Properties
        public int LocationId { get; set; }
        [Required]
        public Point Location { get; set; }


        public ShearForce(double magnitude, Direction direction, Point location) : base(magnitude, direction)
        {
            Location = location;
            Type = VectorType.ShearForce;
        }

        //Constructor for EF Core
        private ShearForce(double magnitude, Direction direction) : base(magnitude, direction) => Type = VectorType.ShearForce;

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            else
            {
                ShearForce shearForceToCompare = (ShearForce)obj;

                return (Magnitude == shearForceToCompare.Magnitude) && (Location.X == shearForceToCompare.Location.X);
            }
        }

        public override int GetHashCode()
        {
            return Magnitude.GetHashCode() ^ Location.X.GetHashCode();
        }

        public override string ToString()
        {
            return $"Q = {Magnitude} N" +
                $"The location from the coordinate origin (x coordinate): {Location.X} mm" +
                $"Force direction: {Direction}";
        }
    }
}
