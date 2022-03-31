namespace StructuralMechanics.Models
{
    public class Moment : VectorPhysicalQuantity
    {
        public Moment(double magnitude, Direction direction) : base(magnitude, direction)
        {
            this.VectorType = VectorType.Moment;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            else
            {
                Moment momentToCampare = (Moment)obj;

                return this.Magnitude == momentToCampare.Magnitude;
            }
        }

        public override int GetHashCode()
        {
            return this.Magnitude.GetHashCode();
        }

        public override string ToString()
        {
            return $"M = {this.Magnitude}" +
                    $"Moment direction: {this.Direction}";
        }
    }
}
