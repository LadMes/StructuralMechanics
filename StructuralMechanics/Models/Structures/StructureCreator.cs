using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Models.Structures
{
    public static class StructureCreator
    {
        private delegate Structure CreateStructure(ProjectViewModel model);
        private readonly static Dictionary<StructureType, CreateStructure> structureCreators = new()
        {
            { StructureType.ThinWalledStructure, CreateThinWalledStructure },
            { StructureType.CirclePlate, CreateCirclePlate },
            { StructureType.RotationalShell, CreateRotationalShell },
        };

        public static Structure GetStructure(ProjectViewModel model)
        {
            var create = structureCreators[model.StructureType];
            return create(model);
        }

        private static Structure CreateThinWalledStructure(ProjectViewModel model)
        {
            return new ThinWalledStructure(model.ThinWalledStructureType!.Value);
        }

        private static Structure CreateCirclePlate(ProjectViewModel model)
        {
            return new CirclePlate();
        }

        private static Structure CreateRotationalShell(ProjectViewModel model)
        {
            return new RotationalShell();
        }
    }
}
