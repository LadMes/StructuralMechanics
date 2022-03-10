namespace StructuralMechanics.Models
{
    public class VerticalLine : SimpleShape
    {
        public VerticalLine(Point firstPoint, Point secondPoint, double thickness) : base(firstPoint, secondPoint, thickness)
        {
            this.GeometryType = GeometryType.VerticalLine;
        }

        //Constructor for EF Core
        private VerticalLine(double thickness) : base(thickness)
        {
            this.GeometryType = GeometryType.VerticalLine;
        }

        protected override void ChangePointsOrder(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.Y > secondPoint.Y)
            {
                this.FirstPoint = secondPoint;
                this.SecondPoint = firstPoint;
            }
        }

        protected override void CalculateLength()
        {
            this.Length = this.SecondPoint.Y - this.FirstPoint.Y;
        }

        protected override void CalculateFirstMomentOfArea()
        {
            this.FirstMomentOfArea = (Math.Pow(this.FirstPoint.Y, 2) * this.Thickness) / 2;
        }

        protected override void CalculateSecondMomentOfArea()
        {
            this.SecondMomentOfArea = (Math.Pow(this.FirstPoint.Y, 3) * this.Thickness) / 3;
        }
    }
}
