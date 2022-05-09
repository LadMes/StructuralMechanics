using Microsoft.AspNetCore.Mvc.Filters;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Filters
{
    public class ProjectViewModelValidatorFilter : IActionFilter
    {
        private delegate void ValidateModel();
        private Dictionary<StructureType, ValidateModel> validators = new ();
        private string ErrorMessage { get; set; } = "";
        private ProjectViewModel Model { get; set; } = new ();

        public ProjectViewModelValidatorFilter()
        {
            InitializeDictionary();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            GetModelFromContext(context);
            if (context.ModelState.IsValid)
            {
                Validate(Model.StructureType);
                if (ErrorMessage != "")
                    context.ModelState.AddModelError(string.Empty, ErrorMessage);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        private void GetModelFromContext(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("model"))
            {
                Model = (ProjectViewModel)context.ActionArguments["model"]!;
            }
        }

        private void Validate(StructureType type)
        {
            if (Enum.IsDefined(typeof(StructureType), Model.StructureType))
            {
                validators[type]();
            }
            else
            {
                ErrorMessage = "Please Select Structure Type";
            }
        }

        private void ValidateThinWalledStructure()
        {
            if (Model.ThinWalledStructureType == null)
            {
                ErrorMessage = "Select Thin-walled Structure Type";
            }
            else if (Model.ThinWalledStructureType == ThinWalledStructureType.OneTimeClosed)
            {
                ErrorMessage = "One-time closed Thin-walled Structure type is not supported right now";
            }
        }

        private void ValidateCirclePlate()
        {
            ErrorMessage = "Others types aren't supported right now";
        }

        private void ValidateRotationalShell()
        {
            ErrorMessage = "Others types aren't supported right now";
        }

        private void InitializeDictionary()
        {
            validators.Add(StructureType.ThinWalledStructure, ValidateThinWalledStructure);
            validators.Add(StructureType.CirclePlate, ValidateCirclePlate);
            validators.Add(StructureType.RotationalShell, ValidateRotationalShell);
        }
    }
}
