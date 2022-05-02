using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.CrossSection
{
    public class SlopeLine : CrossSectionPart
    {
        [Required]
        public SlopeAngle SlopeAngle { get; private set; }


        public SlopeLine(Point firstPoint, Point secondPoint, double thickness) : base(firstPoint, secondPoint, thickness)
        {
            Type = CrossSectionPartType.SlopeLine;
        }

        //Constructor for EF Core 6.0.x: Currently it's not possible to pass navigation properties to constructors.
        private SlopeLine(double thickness) : base(thickness) => Type = CrossSectionPartType.SlopeLine;

        protected override void ChangePointsOrder(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.X > secondPoint.X)
            {
                FirstPoint = secondPoint;
                SecondPoint = firstPoint;   
            }

            if (firstPoint.Y > secondPoint.Y)
                SlopeAngle = SlopeAngle.AcuteAngle;
            else
                SlopeAngle = SlopeAngle.ObtuseAngle;
        }

        protected override void CalculateLength()
        {
            double xCathetusLength = SecondPoint.X - FirstPoint.X;

            double yCathetusLength;

            if (SlopeAngle == SlopeAngle.AcuteAngle)
                yCathetusLength = SecondPoint.Y - FirstPoint.Y;  
            else
                yCathetusLength = FirstPoint.Y - SecondPoint.Y;

            Length = Math.Sqrt((Math.Pow(xCathetusLength, 2) + Math.Pow(yCathetusLength, 2)));
        }

        protected override void CalculateFirstMomentOfArea()
        {
            double ySum = FirstPoint.Y + SecondPoint.Y;

            FirstMomentOfArea = (ySum * Length * Thickness) / 2;
        }

        protected override void CalculateSecondMomentOfArea()
        {
            double ySum = (FirstPoint.Y * SecondPoint.Y) + Math.Pow(FirstPoint.Y, 2) + Math.Pow(SecondPoint.Y, 2);

            SecondMomentOfArea = (ySum * Length * Thickness) / 3;
        }
    }
}
