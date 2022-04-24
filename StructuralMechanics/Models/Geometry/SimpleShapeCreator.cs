using StructuralMechanics.Areas.Project.ViewModels;

namespace StructuralMechanics.Models
{
    public static class SimpleShapeCreator
    {
        private delegate SimpleShape CreateSimpleShapeObject(Point firstPoint, Point secondPoint, double thickness);
        private static Dictionary<GeometryType, CreateSimpleShapeObject> simpleShapeCreators = new Dictionary<GeometryType, CreateSimpleShapeObject>()
        {
            { GeometryType.Arc,  CreateArcObject },
            { GeometryType.SlopeLine,  CreateSlopeLineObject },
            { GeometryType.HorizontalLine,  CreateHorizontalLineObject },
            { GeometryType.VerticalLine,  CreateVerticalLineObject },
        };
        public static (bool, SimpleShape?) GetSimpleShapeObject(SimpleShapeViewModel model)
        {
            if (model != null && model.GeometryType != null && Enum.IsDefined(typeof(GeometryType), model.GeometryType))
            {
                var createMethod = GetCreateMethod(model.GeometryType.GetValueOrDefault());
                return (true, createMethod(model.FirstPoint!, model.SecondPoint!, model.Thickness));
            }
            else
            {
                return (false, null);
            }
        }

        private static CreateSimpleShapeObject GetCreateMethod(GeometryType geometryType)
        {
            return simpleShapeCreators[geometryType];
        }
        private static Arc CreateArcObject(Point firstPoint, Point secondPoint, double thickness)
        {
            return new Arc(firstPoint, secondPoint, thickness);
        }
        private static SlopeLine CreateSlopeLineObject(Point firstPoint, Point secondPoint, double thickness)
        {
            return new SlopeLine(firstPoint, secondPoint, thickness);
        }
        private static HorizontalLine CreateHorizontalLineObject(Point firstPoint, Point secondPoint, double thickness)
        {
            return new HorizontalLine(firstPoint, secondPoint, thickness);
        }
        private static VerticalLine CreateVerticalLineObject(Point firstPoint, Point secondPoint, double thickness)
        {
            return new VerticalLine(firstPoint, secondPoint, thickness);
        }
    }
}
