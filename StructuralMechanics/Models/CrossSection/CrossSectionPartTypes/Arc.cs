using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public class Arc : CrossSectionPart
    {
        private double radius;
        [Required]
        public double Radius { get { return radius; } private set { radius = Math.Round(value, 2); } }
        [Required]
        public ArcQuadrant ArcQuadrant { get; private set; }


        public Arc(Point firstPoint, Point secondPoint, double thickness) : base(firstPoint, secondPoint, thickness)
        {
            Type = CrossSectionPartType.Arc;
        }

        //Constructor for EF Core
        private Arc(double thickness) : base(thickness) => Type = CrossSectionPartType.Arc;

        protected override void ChangePointsOrder(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.X > secondPoint.X)
            {
                FirstPoint = secondPoint;
                SecondPoint = firstPoint;    
            }

            if (FirstPoint.Y > SecondPoint.Y)
                ArcQuadrant = ArcQuadrant.FirstQuadrant;
            else
                ArcQuadrant = ArcQuadrant.SecondQuadrant;
        }

        protected override void CalculateLength()
        {
            CalculateRadius();
            Length = (Math.Round(Math.PI, 2) * Radius) / 4;
        }

        private void CalculateRadius()
        {
            if (ArcQuadrant == ArcQuadrant.SecondQuadrant)
                Radius = SecondPoint.Y - FirstPoint.Y;
            else
                Radius = FirstPoint.Y - SecondPoint.Y;
        }

        protected override void CalculateFirstMomentOfArea()
        {
            FirstMomentOfArea = Math.Pow(Radius, 2) * Thickness;
        }

        protected override void CalculateSecondMomentOfArea()
        {
            SecondMomentOfArea = (Math.Pow(Radius, 3) * Thickness * Math.Round(Math.PI, 2)) / 4;
        }
    }
}
