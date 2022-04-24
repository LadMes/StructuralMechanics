using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Models
{
    public static class StructureCreator
    {
        private delegate (bool, string, Structure?) CreateStructureObject(ProjectViewModel model);
        private static Dictionary<StructureType, CreateStructureObject> structureCreators = new Dictionary<StructureType, CreateStructureObject>()
        {
            { StructureType.ThinWalledStructure, CreateThinWalledStructureObject },
            { StructureType.CirclePlate, CreateCirclePlateObject },
            { StructureType.RotationalShell, CreateRotationalShellObject },
        };
        public static (bool, string, Structure?) GetStructureObject(ProjectViewModel model)
        {
            if (model != null && model.StructureType != null && Enum.IsDefined(typeof(StructureType), model.StructureType))
            {
                var creatorMethod = GetCreateMethod(model.StructureType.GetValueOrDefault());
                return creatorMethod(model);
            }
            else
            {
                return (false, "Select Structure Type", null);
            }
        }

        private static CreateStructureObject GetCreateMethod(StructureType structureType)
        {
            return structureCreators[structureType];
        }
        private static (bool, string, Structure?) CreateThinWalledStructureObject(ProjectViewModel model)
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
            return errorMessage == "" ? (true, errorMessage, new ThinWalledStructure(model.ThinWalledStructureType!.Value)) 
                                      : (false, errorMessage, null);
        }
        private static (bool, string, Structure?) CreateCirclePlateObject(ProjectViewModel model)
        {
            string errorMessage = "Others types aren't supported right now";
            return (false, errorMessage, null);
        }
        private static (bool, string, Structure?) CreateRotationalShellObject(ProjectViewModel model)
        {
            string errorMessage = "Others types aren't supported right now";
            return (false, errorMessage, null);
        }
    }
}
