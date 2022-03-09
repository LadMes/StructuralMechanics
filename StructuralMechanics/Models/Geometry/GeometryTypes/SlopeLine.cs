namespace StructuralMechanics.Models
{
    public class SlopeLine : BasicShape
    {
        public SlopeAngle SlopeAngle { get; protected set; }


        public SlopeLine(Point firstPoint, Point secondPoint, double thickness) : base(firstPoint, secondPoint, thickness)
        {
            this.GeometryType = GeometryType.SlopeLine;
        }

        protected override void ChangePointsOrder(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.X > secondPoint.X)
            {
                this.FirstPoint = secondPoint;
                this.SecondPoint = firstPoint;   
            }

            if (firstPoint.Y > secondPoint.Y)
                this.SlopeAngle = SlopeAngle.AcuteAngle;
            else
                this.SlopeAngle = SlopeAngle.ObtuseAngle;
        }

        protected override void CalculateLength()
        {
            double xCathetusLength = this.SecondPoint.X - this.FirstPoint.X;

            double yCathetusLength;

            if (this.SlopeAngle == SlopeAngle.AcuteAngle)
                yCathetusLength = this.SecondPoint.Y - this.FirstPoint.Y;  
            else
                yCathetusLength = this.FirstPoint.Y - this.SecondPoint.Y;

            this.Length = Math.Sqrt((Math.Pow(xCathetusLength, 2) + Math.Pow(yCathetusLength, 2)));
        }

        protected override void CalculateFirstMomentOfArea()
        {
            double ySum = this.FirstPoint.Y + this.SecondPoint.Y;

            this.FirstMomentOfArea = (ySum * this.Length * this.Thickness) / 2;
        }

        protected override void CalculateSecondMomentOfArea()
        {
            double ySum = (this.FirstPoint.Y * this.SecondPoint.Y) + Math.Pow(this.FirstPoint.Y, 2) + Math.Pow(this.SecondPoint.Y, 2);

            this.SecondMomentOfArea = (ySum * this.Length * this.Thickness) / 3;
        }
    }
}
