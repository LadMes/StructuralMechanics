using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.CrossSection
{
    public class Point : CrossSectionElement, IComparable<Point>
    {
        [Required]
        public double X { get; private set; }
        [Required]
        public double Y { get; private set; }
        [Required]
        public PointPositionInCoordGrid PointPosition { get; private set; }

        public event Action PointChanged = delegate { };

        public Point(double x, double y)
        {
            ElementType = CrossSectionElementType.Point;
            SetProperties(x, y);
        }

        public void Edit(double x, double y)
        {
            SetProperties(x, y);
            PointChanged();
        }

        private void SetProperties(double x, double y)
        {
            X = x;
            Y = y;
            AssignPointPositionProperty();
        }

        public void AddEventListeners(List<IPointChangedListener> listeners)
        {
            foreach (var listener in listeners)
            {
                PointChanged += listener.OnPointChanged;
            }
        }

        private void AssignPointPositionProperty()
        {
            if (X != 0 && Y != 0)
            {
                PointPosition = PointPositionInCoordGrid.PointIsNotOnCoordAxes;
            }
            else if (Y == 0 && X != 0)
            {
                PointPosition = PointPositionInCoordGrid.PointIsOnXAxis;
            }
            else if (X == 0 && Y != 0)
            {
                PointPosition = PointPositionInCoordGrid.PointIsOnYAxis;
            }
            else
            {
                PointPosition = PointPositionInCoordGrid.StartingPoint;
            }
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Point pointToCompare = (Point)obj;

                return (X == pointToCompare.X) && (Y == pointToCompare.Y);
            }
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override string ToString()
        {
            return $"Point(mm) ({X}; {Y})";
        }

        public int CompareTo(Point? other)
        {
            return X.CompareTo(other?.X);
        }
    }

}
