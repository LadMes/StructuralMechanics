namespace StructuralMechanics.Models
{
    public class HorizontalLine : CrossSectionPart
    {
        public HorizontalLine(Point firstPoint, Point secondPoint, double thickness) : base(firstPoint, secondPoint, thickness)
        {
            Type = CrossSectionPartType.HorizontalLine;
        }

        //Constructor for EF Core 6.0.x: Currently it's not possible to pass navigation properties to constructors.
        private HorizontalLine(double thickness) : base(thickness) => Type = CrossSectionPartType.HorizontalLine;

        protected override void ChangePointsOrder(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.X > secondPoint.X)
            {
                FirstPoint = secondPoint;
                SecondPoint = firstPoint;
            }
        }

        protected override void CalculateLength()
        {
            Length = SecondPoint.X - FirstPoint.X;
        }

        protected override void CalculateFirstMomentOfArea()
        {
            FirstMomentOfArea = FirstPoint.Y * Thickness * Length;
        }

        protected override void CalculateSecondMomentOfArea()
        {
            SecondMomentOfArea = Math.Pow(FirstPoint.Y, 2) * Thickness * Length;
        }
    }
}
