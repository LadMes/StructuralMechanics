using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public abstract class SimpleShape : GeneralGeometryProperties
    {
        [Required]
        public double Thickness { get; set; }
        [Required]
        public double Length { get; protected set; }

        //Navigation Properties
        public int FirstPointId { get; set; }
        [Required]
        public Point FirstPoint { get; set; }
        public int SecondPointId { get; set; }
        [Required]
        public Point SecondPoint { get; set; }
        

        public SimpleShape(Point firstPoint, Point secondPoint, double thickness)
        {
            this.FirstPoint = firstPoint;
            this.SecondPoint = secondPoint;
            this.Thickness = thickness;
            this.ChangePointsOrder(firstPoint, secondPoint);
            this.CalculateLength();
            this.CalculateFirstMomentOfArea();
            this.CalculateSecondMomentOfArea();
        }

        //Constructor for EF Core
        protected SimpleShape(double thickness)
        {
            this.Thickness = thickness;
        }

        protected abstract void ChangePointsOrder(Point firstPoint, Point secondPoint);

        protected abstract void CalculateLength();

        protected abstract void CalculateFirstMomentOfArea();

        protected abstract void CalculateSecondMomentOfArea();

        public void ChangeThickness(double thickness)
        {
            this.Thickness = thickness;
            this.CalculateFirstMomentOfArea();
            this.CalculateSecondMomentOfArea();
        }

        public void ChangeFirstPoint(Point firstPoint)
        {
            this.FirstPoint = firstPoint;
            this.ChangePointsOrder(firstPoint, SecondPoint);
            this.CalculateLength();
            this.CalculateFirstMomentOfArea();
            this.CalculateSecondMomentOfArea();
        }

        public void ChangeSecondPoint(Point secondPoint)
        {
            this.SecondPoint = secondPoint;
            this.ChangePointsOrder(FirstPoint, secondPoint);
            this.CalculateLength();
            this.CalculateFirstMomentOfArea();
            this.CalculateSecondMomentOfArea();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                SimpleShape shapeToCompare = (SimpleShape)obj;

                return (this.FirstPoint == shapeToCompare.FirstPoint) && (this.SecondPoint == shapeToCompare.SecondPoint)
                       && (this.Thickness == shapeToCompare.Thickness) && (this.GeometryType == shapeToCompare.GeometryType);
            }
        }

        public override int GetHashCode()
        {
            return this.FirstPoint.GetHashCode() ^ this.SecondPoint.GetHashCode() ^ this.Thickness.GetHashCode() ^ this.GeometryType.GetHashCode();
        }

        public override string ToString()
        {
            return $"Geometry type - {this.GeometryType}" +
                $"\nThicknes = {this.Thickness} mm" +
                $"\nPoints: {this.FirstPoint} - {this.SecondPoint}" +
                $"\nSrx = {this.FirstMomentOfArea} mm\u00B3" +
                $"\nIrx = {this.SecondMomentOfArea} mm\u2074";
        }
    }
}
