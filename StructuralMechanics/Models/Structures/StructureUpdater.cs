using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Models.Structures
{
    public static class StructureUpdater
    {
        private delegate Structure UpdateStructure(ProjectViewModel model, Structure structure);
        private readonly static Dictionary<StructureType, UpdateStructure> structureUpdaters = new()
        {
            { StructureType.ThinWalledStructure, UpdateThinWalledStructure },
            { StructureType.CirclePlate, UpdateCirclePlate },
            { StructureType.RotationalShell, UpdateRotationalShell },
        };

        public static Structure GetUpdatedStructure(ProjectViewModel model, Structure structure)
        {
            var update = structureUpdaters[model.StructureType];
            return update(model, structure);
        }

        private static Structure UpdateThinWalledStructure(ProjectViewModel model, Structure structure)
        {
            ((ThinWalledStructure)structure).ThinWalledStructureType = model.ThinWalledStructureType!.Value;
            return structure;
        }

        private static Structure UpdateCirclePlate(ProjectViewModel model, Structure structure)
        {
            // Some logic for update this structure when the module will be done
            return structure;
        }

        private static Structure UpdateRotationalShell(ProjectViewModel model, Structure structure)
        {
            // Some logic for update this structure when the module will be done
            return structure;
        }
    }
}
