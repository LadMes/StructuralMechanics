using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public class Point : GeometryObject, IComparable<Point>
    {
        [Required]
        public double X { get; set; }
        [Required]
        public double Y { get; set; }
        [Required]
        public PointPositionInCoordGrid PointPosition { get; private set; }


        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.GeometryType = GeometryType.Point;
            AssignPointPositionProperty();
        }   

        private void AssignPointPositionProperty()
        {
            if (this.X != 0 && this.Y != 0)
            {
                this.PointPosition = PointPositionInCoordGrid.PointIsNotOnCoordAxes;
            }
            else if (this.Y == 0 && this.X != 0)
            {
                this.PointPosition = PointPositionInCoordGrid.PointIsOnXAxis;
            }
            else if (this.X == 0 && this.Y != 0)
            {
                this.PointPosition = PointPositionInCoordGrid.PointIsOnYAxis;
            }
            else
            {
                this.PointPosition = PointPositionInCoordGrid.StartingPoint;
            }
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Point pointToCompare = (Point)obj;

                return (this.X == pointToCompare.X) && (this.Y == pointToCompare.Y);
            }
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

        public override string ToString()
        {
            return $"Point(mm) ({this.X}; {this.Y})";
        }

        public int CompareTo(Point other)
        {
            return this.X.CompareTo(other.X);
        }
    }

}
