using StructuralMechanics.Areas.Project.ViewModels;

namespace StructuralMechanics.Models.CrossSection
{
    public static class CrossSectionPartCreator
    {
        private delegate CrossSectionPart CreateCrossSectionPart(Point firstPoint, Point secondPoint, double thickness);
        private readonly static Dictionary<CrossSectionPartType, CreateCrossSectionPart> crossSectionPartCreators = new()
        {
            { CrossSectionPartType.Arc,  CreateArc },
            { CrossSectionPartType.SlopeLine,  CreateSlopeLine },
            { CrossSectionPartType.HorizontalLine,  CreateHorizontalLine },
            { CrossSectionPartType.VerticalLine,  CreateVerticalLine },
        };

        public static CrossSectionPart? Create(CrossSectionPartViewModel model)
        {
            if (model != null && Enum.IsDefined(typeof(CrossSectionPartType), model.Type))
            {
                var create = GetCreateMethod(model.Type);
                return create(model.FirstPoint!, model.SecondPoint!, model.Thickness);
            }
            else
            {
                return null;
            }
        }

        private static CreateCrossSectionPart GetCreateMethod(CrossSectionPartType type)
        {
            return crossSectionPartCreators[type];
        }

        private static Arc CreateArc(Point firstPoint, Point secondPoint, double thickness)
        {
            return new Arc(firstPoint, secondPoint, thickness);
        }

        private static SlopeLine CreateSlopeLine(Point firstPoint, Point secondPoint, double thickness)
        {
            return new SlopeLine(firstPoint, secondPoint, thickness);
        }

        private static HorizontalLine CreateHorizontalLine(Point firstPoint, Point secondPoint, double thickness)
        {
            return new HorizontalLine(firstPoint, secondPoint, thickness);
        }

        private static VerticalLine CreateVerticalLine(Point firstPoint, Point secondPoint, double thickness)
        {
            return new VerticalLine(firstPoint, secondPoint, thickness);
        }
    }
}
