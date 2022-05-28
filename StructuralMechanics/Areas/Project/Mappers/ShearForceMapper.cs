using StructuralMechanics.Areas.Project.ViewModels;

namespace StructuralMechanics.Areas.Project.Mappers
{
    public static class ShearForceMapper
    {
        public static ShearForceViewModel Map(ShearForce force)
        {
            return new ShearForceViewModel()
            {
                Id = force.Id,
                Magnitude = force.Magnitude,
                LocationId = force.LocationId,
                Location = force.Location
            };
        }
    }
}
