using StructuralMechanics.Areas.Project.ViewModels;

namespace StructuralMechanics.Areas.Project.Utilities
{
    public static class SimpleShapeHelper
    {
        public static (bool, SimpleShape?) GetSimpleShapeObjectByType(SimpleShapeViewModel model)
        {
            if (model.GeometryType == GeometryType.Arc)
            {
                return (true, new Arc(model.FirstPoint, model.SecondPoint, model.Thickness));
            }
            else if (model.GeometryType == GeometryType.SlopeLine)
            {
                return (true, new SlopeLine(model.FirstPoint, model.SecondPoint, model.Thickness));
            }
            else if (model.GeometryType == GeometryType.HorizontalLine)
            {
                return (true, new HorizontalLine(model.FirstPoint, model.SecondPoint, model.Thickness));
            }
            else if (model.GeometryType == GeometryType.VerticalLine)
            {
                return (true, new VerticalLine(model.FirstPoint, model.SecondPoint, model.Thickness));
            }
            else
            {
                return (false, null);
            }
        }
    }
}
