namespace StructuralMechanics.Models
{
    public class StrengthMember
    {
        private double reductionCoefficient;
        private double area;
        private Point location;
        private double firstMomemntOfArea;
        private double secondMomemntOfArea;
        private readonly GeometryType geometryType = GeometryType.StrengthMember;

        public StrengthMember(double reductionCoefficient, double area, Point location)
        {
            this.ReductionCoefficient = reductionCoefficient;
            this.Area = area;
            this.Location = location;
            CalculateFirstMomentOfArea();
            CalculateSecondMomentOfArea();
        }

        public double ReductionCoefficient
        {
            get => this.reductionCoefficient;
            private set
            {
                this.reductionCoefficient = Math.Round(value, 2);
            }
        }

        public double Area
        {
            get => this.area;
            private set
            {
                this.area = Math.Round(value, 2);
            }
        }

        public Point Location
        {
            get => this.location;
            private set => this.location = value;
        }

        public double FirstMomemntOfArea
        {
            get => this.firstMomemntOfArea;

            private set
            {
                this.firstMomemntOfArea = Math.Round(value, 2);
            }
        }

        public double SecondMomemntOfArea
        {
            get => this.secondMomemntOfArea;

            private set
            {
                this.secondMomemntOfArea = Math.Round(value, 2);
            }
        }

        public GeometryType GeometryType => this.geometryType;

        private void CalculateFirstMomentOfArea()
        {
            this.FirstMomemntOfArea = this.reductionCoefficient * this.Location.Y * this.Area; 
        }

        private void CalculateSecondMomentOfArea()
        {
            this.SecondMomemntOfArea = this.reductionCoefficient * Math.Pow(this.Location.Y, 2) * this.Area;
        }

        public void ChangeReductionCoefficient(double reductionCoefficient)
        {
            this.ReductionCoefficient = reductionCoefficient;
            CalculateFirstMomentOfArea();
            CalculateSecondMomentOfArea();
        }

        public void ChangeArea(double area)
        {
            this.Area = area;
            CalculateFirstMomentOfArea();
            CalculateSecondMomentOfArea();
        }

        public void ChangeLocation(Point location)
        {
            this.Location = location;
            CalculateFirstMomentOfArea();
            CalculateSecondMomentOfArea();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            else
            {
                StrengthMember strengthMemberToCompare = (StrengthMember)obj;
                return (this.reductionCoefficient == strengthMemberToCompare.reductionCoefficient) && (this.Area == strengthMemberToCompare.Area)
                        && (this.Location.Y == strengthMemberToCompare.Location.Y);
            }
        }

        public override int GetHashCode()
        {
            return this.ReductionCoefficient.GetHashCode() ^ this.Area.GetHashCode() ^ this.Location.Y.GetHashCode();
        }

        public override string ToString()
        {
            return $"Strength member properties:" +
                $"\n\u03C6 = {this.ReductionCoefficient}" +
                $"\nArea = {this.Area} mm\u00B2" +
                $"\nLocation - {this.Location}" +
                $"\nSrx = {this.FirstMomemntOfArea} mm\u00B3" +
                $"\nIrx = {this.SecondMomemntOfArea} mm\u2074";
        }
    }
}
