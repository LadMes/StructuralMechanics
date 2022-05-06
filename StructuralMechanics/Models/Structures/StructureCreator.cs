using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Models.Structures
{
    public static class StructureCreator
    {
        private delegate (bool, string, Structure?) CreateStructure(ProjectViewModel model);
        private readonly static Dictionary<StructureType, CreateStructure> structureCreators = new()
        {
            { StructureType.ThinWalledStructure, CreateThinWalledStructure },
            { StructureType.CirclePlate, CreateCirclePlate },
            { StructureType.RotationalShell, CreateRotationalShell },
        };
        public static (bool, string, Structure?) GetStructure(ProjectViewModel model)
        {
            if (model != null && Enum.IsDefined(typeof(StructureType), model.StructureType))
            {
                var creatorMethod = GetCreateMethod(model.StructureType);
                return creatorMethod(model);
            }
            else
            {
                return (false, "Select Structure Type", null);
            }
        }

        private static CreateStructure GetCreateMethod(StructureType type)
        {
            return structureCreators[type];
        }
        private static (bool, string, Structure?) CreateThinWalledStructure(ProjectViewModel model)
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
        private static (bool, string, Structure?) CreateCirclePlate(ProjectViewModel model)
        {
            string errorMessage = "Others types aren't supported right now";
            return (false, errorMessage, null);
        }
        private static (bool, string, Structure?) CreateRotationalShell(ProjectViewModel model)
        {
            string errorMessage = "Others types aren't supported right now";
            return (false, errorMessage, null);
        }
    }
}
