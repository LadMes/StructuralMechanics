using StructuralMechanics.Areas.Project.ViewModels;

namespace StructuralMechanics.Areas.Project.Mappers
{
    public static class CrossSectionPartMapper
    {
        public static CrossSectionPartViewModel Map(CrossSectionPart crossSectionPart)
        {
            return new CrossSectionPartViewModel()
            {
                Id = crossSectionPart.Id,
                Type = crossSectionPart.Type,
                FirstPoint = crossSectionPart.FirstPoint,
                SecondPoint = crossSectionPart.SecondPoint,
                Thickness = crossSectionPart.Thickness,
                FirstPointId = crossSectionPart.FirstPointId,
                SecondPointId = crossSectionPart.SecondPointId,
            };
        }
    }
}
