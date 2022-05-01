using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Models
{
    public static class StructureUpdater
    {
        private delegate (bool, string, Structure) UpdateStructure(ProjectViewModel model, Structure structure);
        private readonly static Dictionary<StructureType, UpdateStructure> structureUpdaters = new()
        {
            { StructureType.ThinWalledStructure, UpdateThinWalledStructure },
            { StructureType.CirclePlate, UpdateCirclePlate },
            { StructureType.RotationalShell, UpdateRotationalShell },
        };
        public static (bool, string, Structure) GetUpdatedStructure(ProjectViewModel model, Structure structure)
        {
            if (model != null && model.StructureType != null && Enum.IsDefined(typeof(StructureType), model.StructureType))
            {
                var updateMethod = GetUpdateMethod(model.StructureType.GetValueOrDefault());
                return updateMethod(model, structure);
            }
            else
            {
                return (false, "Something went wrong!", structure);
            }    
        }

        private static UpdateStructure GetUpdateMethod(StructureType type)
        {
            return structureUpdaters[type];
        }
        private static (bool, string, Structure) UpdateThinWalledStructure(ProjectViewModel model, Structure structure)
        {
            string errorMessage = "";
            if (model.ThinWalledStructureType == null)
            {
                errorMessage = "Select Thin-walled Structure Type";
            }
            else if (model.ThinWalledStructureType == ThinWalledStructureType.OneTimeClosed)
            {
                errorMessage = "One-time closed Thin-walled Structure type is not supported right now";
            }
            ((ThinWalledStructure)structure).ThinWalledStructureType = model.ThinWalledStructureType!.Value;

            return errorMessage == "" ? (true, errorMessage, structure) : (false, errorMessage, structure);
        }
        private static (bool, string, Structure) UpdateCirclePlate(ProjectViewModel model, Structure structure)
        {
            string errorMessage = "Others types aren't supported right now";
            return (false, errorMessage, structure);
        }
        private static (bool, string, Structure) UpdateRotationalShell(ProjectViewModel model, Structure structure)
        {
            string errorMessage = "Others types aren't supported right now";
            return (false, errorMessage, structure);
        }
    }
}
