using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.CrossSection
{
    public abstract class CrossSectionPart : AreaProperties
    {
        private double length;
        [Required]
        public double Thickness { get; protected set; }
        [Required]
        public double Length { get { return length; } protected set { length = Math.Round(value, 2); } }
        [Required]
        public CrossSectionPartType Type { get; protected set; }

        public int FirstPointId { get; set; }
        [Required]
        public Point FirstPoint { get; protected set; }
        public int SecondPointId { get; set; }
        [Required]
        public Point SecondPoint { get; protected set; }

        public CrossSectionPart(Point firstPoint, Point secondPoint, double thickness)
        {
            ElementType = CrossSectionElementType.CrossSectionPart;
            SetProperties(firstPoint, secondPoint, thickness);
            CalculateLengthAndAreaProperties();
        }

        //Constructor for EF Core 6.0.x: Currently it's not possible to pass navigation properties to constructors.
        protected CrossSectionPart(double thickness) => Thickness = thickness;

        public void OnPointChanged()
        {
            CalculateLengthAndAreaProperties();
        }

        public void Edit(Point firstPoint, Point secondPoint, double thickness)
        {
            SetProperties(firstPoint, secondPoint, thickness);
            CalculateLengthAndAreaProperties();
        }

        private void CalculateLengthAndAreaProperties()
        {
            ChangePointsOrder(FirstPoint, SecondPoint);
            CalculateLength();
            CalculateFirstMomentOfArea();
            CalculateSecondMomentOfArea();
        }

        private void SetProperties(Point firstPoint, Point secondPoint, double thickness)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            Thickness = thickness;
        }

        protected abstract void ChangePointsOrder(Point firstPoint, Point secondPoint);

        protected abstract void CalculateLength();

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                CrossSectionPart crossSectionPartToCompare = (CrossSectionPart)obj;

                return (FirstPoint == crossSectionPartToCompare.FirstPoint) && (SecondPoint == crossSectionPartToCompare.SecondPoint)
                       && (Thickness == crossSectionPartToCompare.Thickness) && (Type == crossSectionPartToCompare.Type);
            }
        }

        public override int GetHashCode()
        {
            return FirstPoint.GetHashCode() ^ SecondPoint.GetHashCode() ^ Thickness.GetHashCode() ^ Type.GetHashCode();
        }

        public override string ToString()
        {
            return $"Part type - {Type}" +
                $"\nThicknes = {Thickness} mm" +
                $"\nPoints: {FirstPoint} - {SecondPoint}" +
                $"\nSrx = {FirstMomentOfArea} mm\u00B3" +
                $"\nIrx = {SecondMomentOfArea} mm\u2074";
        }
    }
}
