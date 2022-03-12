using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public class Arc : SimpleShape
    {
        [Required]
        public double Radius { get; private set; }
        [Required]
        public ArcQuadrant ArcQuadrant { get; private set; }


        public Arc(Point firstPoint, Point secondPoint, double thickness) : base(firstPoint, secondPoint, thickness)
        {
            this.GeometryType = GeometryType.Arc;
        }

        //Constructor for EF Core
        private Arc(double thickness) : base(thickness)
        {
            this.GeometryType = GeometryType.Arc;
        }

        protected override void ChangePointsOrder(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.X > secondPoint.X)
            {
                this.FirstPoint = secondPoint;
                this.SecondPoint = firstPoint;    
            }

            if (firstPoint.Y > secondPoint.Y)
                this.ArcQuadrant = ArcQuadrant.FirstQuadrant;
            else
                this.ArcQuadrant = ArcQuadrant.SecondQuadrant;
        }

        protected override void CalculateLength()
        {
            if (this.ArcQuadrant == ArcQuadrant.SecondQuadrant)
                this.Radius = this.SecondPoint.Y - this.FirstPoint.Y;
            else
                this.Radius = this.FirstPoint.Y - this.SecondPoint.Y;

            this.Length = (Math.Round(Math.PI, 2) * this.Radius) / 4;
        }

        protected override void CalculateFirstMomentOfArea()
        {
            this.FirstMomentOfArea = Math.Pow(this.Radius, 2) * this.Thickness;
        }

        protected override void CalculateSecondMomentOfArea()
        {
            this.SecondMomentOfArea = (Math.Pow(this.Radius, 3) * this.Thickness * Math.Round(Math.PI, 2)) / 4;
        }
    }
}
