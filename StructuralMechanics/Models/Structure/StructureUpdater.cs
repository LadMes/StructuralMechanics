using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Models
{
    public static class StructureUpdater
    {
        private delegate (bool, string, Structure) UpdateStructure(ProjectViewModel model, Structure structure);
        private static Dictionary<StructureType, UpdateStructure> structureUpdaters = new Dictionary<StructureType, UpdateStructure>()
        {
            { StructureType.ThinWalledStructure, UpdateThinWalledStructureObject },
            { StructureType.CirclePlate, UpdateCirclePlateObject },
            { StructureType.RotationalShell, UpdateRotationalShellObject },
        };
        public static (bool, string, Structure) GetUpdatedStructureObject(ProjectViewModel model, Structure structure)
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

        private static UpdateStructure GetUpdateMethod(StructureType structureType)
        {
            return structureUpdaters[structureType];
        }
        private static (bool, string, Structure) UpdateThinWalledStructureObject(ProjectViewModel model, Structure structure)
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
        private static (bool, string, Structure) UpdateCirclePlateObject(ProjectViewModel model, Structure structure)
        {
            string errorMessage = "Others types aren't supported right now";
            return (false, errorMessage, structure);
        }
        private static (bool, string, Structure) UpdateRotationalShellObject(ProjectViewModel model, Structure structure)
        {
            string errorMessage = "Others types aren't supported right now";
            return (false, errorMessage, structure);
        }
    }
}
