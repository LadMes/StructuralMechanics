using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Mappers
{
    public static class ProjectMapper
    {
        public static ProjectViewModel Map(Project project, Structure structure)
        {
            return new ProjectViewModel()
            {
                ProjectName = project.ProjectName,
                StructureType = structure.Type,
                ThinWalledStructureType = (structure.Type == StructureType.ThinWalledStructure)
                                           ? ((ThinWalledStructure)structure).ThinWalledStructureType
                                           : null
            };
        }
    }
}
