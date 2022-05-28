using StructuralMechanics.Areas.Project.ViewModels;

namespace StructuralMechanics.Areas.Project.Mappers
{
    public static class MomentMapper
    {
        public static MomentViewModel Map(Moment moment)
        {
            return new MomentViewModel()
            {
                Id = moment.Id,
                Magnitude = moment.Magnitude
            };
        }
    }
}
