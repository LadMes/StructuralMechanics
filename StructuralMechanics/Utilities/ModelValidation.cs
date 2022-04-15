﻿using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Utilities
{
    public static class ModelValidation
    {
        public static bool IsPointValid(this Point point)
        {
            if (point.X < 0 || point.Y < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static (bool check, string errorMessage, Structure? structure) IsStructureValid(CreateProjectViewModel model)
        {
            string errorMessage = "";
            bool check = false;
            Structure? structure = null;
            if (model.StructureType == StructureType.ThinWalledStructure)
            {
                if (model.ThinWalledStructureType == null)
                {
                    errorMessage = "Select Thin-walled Structure Type";
                }
                else if (model.ThinWalledStructureType == ThinWalledStructureType.OneTimeClosed)
                {
                    errorMessage = "One-time closed Thin-walled Structure type is not supported right now";
                }
                else
                {
                    check = true;
                    structure = new ThinWalledStructure(model.ThinWalledStructureType.Value);
                }
            }
            else if (model.StructureType == StructureType.CirclePlate)
            {
                errorMessage = "Others types aren't supported right now";
                structure = new CirclePlate();
            }
            else if (model.StructureType == StructureType.RotationalShell)
            {
                errorMessage = "Others types aren't supported right now";
                structure = new RotationalShell();
            }
            else
            {
                errorMessage = "Select Structure Type";
            }

            return (check, errorMessage, structure);
        }

        public static (bool check, string errorMessage, Structure structure) IsStructureValid(EditProjectViewModel model, Structure structure)
        {
            string errorMessage = "";
            bool check = false;
            if (model.StructureType == StructureType.ThinWalledStructure)
            {
                if (model.ThinWalledStructureType == null)
                {
                    errorMessage = "Select Thin-walled Structure Type";
                }
                else if (model.ThinWalledStructureType == ThinWalledStructureType.OneTimeClosed)
                {
                    errorMessage = "One-time closed Thin-walled Structure type is not supported right now";
                }
                else
                {
                    check = true;
                    ((ThinWalledStructure)structure).ThinWalledStructureType = model.ThinWalledStructureType.Value;
                }
            }
            else if (model.StructureType == StructureType.CirclePlate)
            {
                errorMessage = "Others types aren't supported right now";
            }
            else if (model.StructureType == StructureType.RotationalShell)
            {
                errorMessage = "Others types aren't supported right now";
            }
            else
            {
                errorMessage = "Select Structure Type";
            }

            return (check, errorMessage, structure);
        }
    }
}
