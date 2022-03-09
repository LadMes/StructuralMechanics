namespace StructuralMechanics.Models
{
    public class Moment
    {
        private double magnitude;

        public Moment(double magnitude)
        {
            this.Magnitude = magnitude;
        }

        public double Magnitude
        {
            get => this.magnitude;

            private set
            {
                this.magnitude = Math.Round(value, 2);
            }
        }

        public void ChangeMagnitude(double magnitude)
        {
            this.Magnitude = magnitude;
        }

        public override bool Equals(object obj)
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
            return $"M = {this.Magnitude}";
        }
    }
}
