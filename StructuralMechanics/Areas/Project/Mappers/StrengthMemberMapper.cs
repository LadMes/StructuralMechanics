using StructuralMechanics.Areas.Project.ViewModels;

namespace StructuralMechanics.Areas.Project.Mappers
{
    public static class StrengthMemberMapper
    {
        public static StrengthMemberViewModel Map(StrengthMember model)
        {
            return new StrengthMemberViewModel()
            {
                Area = model.Area,
                ReductionCoefficient = model.ReductionCoefficient,
                Location = model.Location,
                LocationId = model.LocationId
            };
        }
    }
}
