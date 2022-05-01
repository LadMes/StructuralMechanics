using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public class StrengthMember : AreaProperties
    {
        [Required]
        public double ReductionCoefficient { get; private set; }
        [Required]
        public double Area { get; private set; }

        //Navigation Properties
        public int LocationId { get; set; }
        [Required]
        public Point Location { get; private set; }


        public StrengthMember(double reductionCoefficient, double area, Point location)
        {
            ElementType = CrossSectionElementType.StrengthMember;
            SetProperties(reductionCoefficient, area, location);
            CalculateFirstMomentOfArea();
            CalculateSecondMomentOfArea();
        }

        //Constructor for EF Core
        private StrengthMember(double reductionCoefficient, double area)
        {
            ReductionCoefficient = reductionCoefficient;
            Area = area;
        }

        public void OnPointChanged()
        {
            CalculateFirstMomentOfArea();
            CalculateSecondMomentOfArea();
        }

        public void Edit(double reductionCoefficient, double area, Point location)
        {
            SetProperties(reductionCoefficient, area, location);
            CalculateFirstMomentOfArea();
            CalculateSecondMomentOfArea();
        }

        private void SetProperties(double reductionCoefficient, double area, Point location)
        {
            ReductionCoefficient = reductionCoefficient;
            Area = area;
            Location = location;
        }

        protected override void CalculateFirstMomentOfArea()
        {
            FirstMomentOfArea = ReductionCoefficient * Location.Y * Area;
        }

        protected override void CalculateSecondMomentOfArea()
        {
            SecondMomentOfArea = ReductionCoefficient * Math.Pow(Location.Y, 2) * Area;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            else
            {
                StrengthMember strengthMemberToCompare = (StrengthMember)obj;
                return (ReductionCoefficient == strengthMemberToCompare.ReductionCoefficient) && (Area == strengthMemberToCompare.Area)
                        && (Location.Y == strengthMemberToCompare.Location.Y);
            }
        }

        public override int GetHashCode()
        {
            return ReductionCoefficient.GetHashCode() ^ Area.GetHashCode() ^ Location.Y.GetHashCode();
        }

        public override string ToString()
        {
            return $"Strength member properties:" +
                $"\n\u03C6 = {ReductionCoefficient}" +
                $"\nArea = {Area} mm\u00B2" +
                $"\nLocation - {Location}" +
                $"\nSrx = {FirstMomentOfArea} mm\u00B3" +
                $"\nIrx = {SecondMomentOfArea} mm\u2074";
        }
    }
}
