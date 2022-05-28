using StructuralMechanics.Areas.Project.ViewModels;

namespace StructuralMechanics.Areas.Project.Mappers
{
    public static class PointMapper
    {
        public static PointViewModel Map(Point point)
        {
            return new PointViewModel()
            {
                Id = point.Id,
                X = point.X,
                Y = point.Y
            };
        }
    }
}
