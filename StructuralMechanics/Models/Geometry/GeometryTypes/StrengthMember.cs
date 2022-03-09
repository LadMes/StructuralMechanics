using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public class StrengthMember : ShapeSharedInfo
    {
        [Required]
        public double ReductionCoefficient { get; set; }
        [Required]
        public double Area { get; set; }
        [Required]
        public Point Location { get; set; }


        public StrengthMember(double reductionCoefficient, double area, Point location)
        {
            this.ReductionCoefficient = reductionCoefficient;
            this.Area = area;
            this.Location = location;
            this.GeometryType = GeometryType.StrengthMember;
            CalculateFirstMomentOfArea();
            CalculateSecondMomentOfArea();
        }

        private void CalculateFirstMomentOfArea()
        {
            this.FirstMomentOfArea = this.ReductionCoefficient * this.Location.Y * this.Area; 
        }

        private void CalculateSecondMomentOfArea()
        {
            this.SecondMomentOfArea = this.ReductionCoefficient * Math.Pow(this.Location.Y, 2) * this.Area;
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
                return (this.ReductionCoefficient == strengthMemberToCompare.ReductionCoefficient) && (this.Area == strengthMemberToCompare.Area)
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
                $"\nSrx = {this.FirstMomentOfArea} mm\u00B3" +
                $"\nIrx = {this.SecondMomentOfArea} mm\u2074";
        }
    }
}
