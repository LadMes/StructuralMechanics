namespace StructuralMechanics.Models
{
    public class ShearForce
    {
        private double magnitude;
        private Point location;
        private ShearForceDirection shearForceDirection;

        public ShearForce(double magnitude, Point location)
        {
            this.Magnitude = magnitude;
            this.Location = location;
        }

        public double Magnitude
        {
            get => this.magnitude;

            private set
            {
                if (value > 0)
                {
                    this.magnitude = Math.Round(value, 2);
                    this.ShearForceDirection = ShearForceDirection.AlongYAxis;
                }
                   
                else
                {
                    this.magnitude = Math.Round(Math.Abs(value), 2);
                    this.ShearForceDirection = ShearForceDirection.OppositeYAxis;
                }
            }
        }

        public Point Location
        {
            get => this.location;

            private set => this.location = value;
        }

        public ShearForceDirection ShearForceDirection
        {
            get => this.shearForceDirection;

            private set => this.shearForceDirection = value;
        }

        public void ChangeMagnitude(double magnitude)
        {
            this.Magnitude = magnitude;
        }

        public void ChangeLocation(Point location)
        {
            this.Location = location;
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
                $"Force direction: {this.ShearForceDirection}";
        }
    }
}
