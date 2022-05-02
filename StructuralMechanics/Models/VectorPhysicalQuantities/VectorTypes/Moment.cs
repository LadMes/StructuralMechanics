namespace StructuralMechanics.Models.VectorPhysicalQuantities
{
    public class Moment : VectorPhysicalQuantity
    {
        public Moment(double magnitude, Direction direction) : base(magnitude, direction)
        {
            Type = VectorType.Moment;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            else
            {
                Moment momentToCampare = (Moment)obj;

                return Magnitude == momentToCampare.Magnitude;
            }
        }

        public override int GetHashCode()
        {
            return Magnitude.GetHashCode();
        }

        public override string ToString()
        {
            return $"M = {Magnitude}" +
                    $"Moment direction: {Direction}";
        }
    }
}
