namespace StructuralMechanics.Models.CrossSection
{
    public class VerticalLine : CrossSectionPart
    {
        public VerticalLine(Point firstPoint, Point secondPoint, double thickness) : base(firstPoint, secondPoint, thickness)
        {
            Type = CrossSectionPartType.VerticalLine;
        }

        //Constructor for EF Core 6.0.x: Currently it's not possible to pass navigation properties to constructors.
        private VerticalLine(double thickness) : base(thickness) => Type = CrossSectionPartType.VerticalLine;

        protected override void ChangePointsOrder(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.Y > secondPoint.Y)
            {
                FirstPoint = secondPoint;
                SecondPoint = firstPoint;
            }
        }

        protected override void CalculateLength()
        {
            Length = SecondPoint.Y - FirstPoint.Y;
        }

        protected override void CalculateFirstMomentOfArea()
        {
            FirstMomentOfArea = (Math.Pow(SecondPoint.Y, 2) * Thickness) / 2;
        }

        protected override void CalculateSecondMomentOfArea()
        {
            SecondMomentOfArea = (Math.Pow(SecondPoint.Y, 3) * Thickness) / 3;
        }
    }
}
