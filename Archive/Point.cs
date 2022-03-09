namespace StructuralMechanics.Models
{
    public class Point : IComparable<Point>
    {
        private double x;

        private double y;

        private PointPositionInCoordGrid pointPosition;

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
            AssignPointPositionProperty();
        }

        public double X
        {
            get => this.x;
            protected set
            {
                this.x = Math.Round(value, 2);
                //if (value >= 0)
                //    this.x = value;

                //else
                //{
                //    Console.WriteLine("x coordinate cannot be below zero");

                //    while (value < 0)
                //    {
                //        Console.WriteLine("Please input a correct x coordinate");
                //        Double.TryParse(Console.ReadLine(), out value);
                //    }

                //    this.x = value;
                //}
            }
        }

        public double Y
        {
            get => this.y;
            protected set
            {
                this.y = Math.Round(value, 2);
                //if (value >= 0)
                //    this.y = value;

                //else
                //{
                //    Console.WriteLine("y coordinate cannot be below zero");

                //    while (value < 0)
                //    {
                //        Console.WriteLine("Please input a correct y coordinate");
                //        Double.TryParse(Console.ReadLine(), out value);
                //    }

                //    this.y = value;
                //}
            }
        }

        public PointPositionInCoordGrid PointPosition
        {
            get => this.pointPosition;

            private set => this.pointPosition = value;
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

        public override bool Equals(object obj)
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




        //public static Point RetrivePointFromList(List<Point> points)
        //{
        //    int number;

        //    do
        //    {
        //        Int32.TryParse(Console.ReadLine(), out number);
        //    } while (number <= 0);

        //    return points[number - 1];
        //}
    }

}
