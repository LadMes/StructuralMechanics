namespace StructuralMechanics.Models
{
    public class HorizontalLine : Shape
    {
        public HorizontalLine(Point firstPoint, Point secondPoint, double thickness) : base(firstPoint, secondPoint, thickness)
        {
            this.geometryType = GeometryType.HorizontalLine;
        }

        protected override void ChangePointsOrder(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.X > secondPoint.X)
            {
                this.FirstPoint = secondPoint;
                this.SecondPoint = firstPoint;
            }
        }

        protected override void CalculateLength()
        {
            this.Length = this.SecondPoint.X - this.FirstPoint.X;
        }

        protected override void CalculateFirstMomentOfArea()
        {
            this.FirstMomentOfArea = this.FirstPoint.Y * this.Thickness * this.Length;
        }

        protected override void CalculateSecondMomentOfArea()
        {
            this.SecondMomentOfArea = Math.Pow(this.FirstPoint.Y, 2) * this.Thickness * this.Length;
        }
    }
}
