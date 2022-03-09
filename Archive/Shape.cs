namespace StructuralMechanics.Models
{
    public abstract class Shape
    {
        private Point firstPoint;
        private Point secondPoint;
        private double thickness;
        protected double length;
        protected double firstMomemntOfArea;
        protected double secondMomemntOfArea;
        protected GeometryType geometryType;

        public Shape(Point firstPoint, Point secondPoint, double thickness)
        {
            this.FirstPoint = firstPoint;
            this.SecondPoint = secondPoint;
            this.Thickness = thickness;
            this.ChangePointsOrder(firstPoint, secondPoint);
            this.CalculateLength();
            this.CalculateFirstMomentOfArea();
            this.CalculateSecondMomentOfArea();
        }

        public Point FirstPoint
        {
            get => this.firstPoint;
            protected set => this.firstPoint = value;
        }    

        public Point SecondPoint
        {
            get => this.secondPoint;
            protected set => this.secondPoint = value;
        }

        public double Thickness
        {
            get => this.thickness;
            protected set
            {
                this.thickness = Math.Round(value, 2);
            }
        }

        public double Length
        {
            get => this.length;
            protected set => this.length = Math.Round(value, 2);
        }

        public double FirstMomentOfArea
        {
            get => this.firstMomemntOfArea;
            protected set => this.firstMomemntOfArea = Math.Round(value, 2);
        }

        public double SecondMomentOfArea
        {
            get => this.secondMomemntOfArea;
            protected set => this.secondMomemntOfArea = Math.Round(value, 2);
        }

        public GeometryType GeometryType => this.geometryType;

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
                Shape shapeToCompare = (Shape)obj;

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
