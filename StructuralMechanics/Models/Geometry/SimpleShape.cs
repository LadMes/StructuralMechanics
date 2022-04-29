using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public abstract class SimpleShape : GeneralGeometryProperties
    {
        [Required]
        public double Thickness { get; protected set; }
        [Required]
        public double Length { get; protected set; }

        //Navigation Properties
        public int FirstPointId { get; set; }
        [Required]
        public Point FirstPoint { get; protected set; }
        public int SecondPointId { get; set; }
        [Required]
        public Point SecondPoint { get; protected set; }

        public SimpleShape(Point firstPoint, Point secondPoint, double thickness)
        {
            SetSimpleShapeProperties(firstPoint, secondPoint, thickness);
            CalculateSimpleShapeProperties();
        }

        //Constructor for EF Core
        protected SimpleShape(double thickness)
        {
            this.Thickness = thickness;
        }

        public void OnPointChanged()
        {
            CalculateSimpleShapeProperties();
        }

        public void EditSimpleShape(Point firstPoint, Point secondPoint, double thickness)
        {
            SetSimpleShapeProperties(firstPoint, secondPoint, thickness);
            CalculateSimpleShapeProperties();
        }

        private void CalculateSimpleShapeProperties()
        {
            this.ChangePointsOrder(FirstPoint, SecondPoint);
            this.CalculateLength();
            this.CalculateFirstMomentOfArea();
            this.CalculateSecondMomentOfArea();
        }

        private void SetSimpleShapeProperties(Point firstPoint, Point secondPoint, double thickness)
        {
            this.FirstPoint = firstPoint;
            this.SecondPoint = secondPoint;
            this.Thickness = thickness;
        }

        protected abstract void ChangePointsOrder(Point firstPoint, Point secondPoint);

        protected abstract void CalculateLength();

        protected abstract void CalculateFirstMomentOfArea();

        protected abstract void CalculateSecondMomentOfArea();

        public override bool Equals(object? obj)
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
