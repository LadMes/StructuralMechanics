using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Filters
{
    public class PointSetterFilter<T> : IActionFilter where T : ILocation, new()
    {
        private readonly IPointRepository pointRepository;
        private BaseInformationController Controller { get; set; }
        private T Model { get; set; } = new();
        private string ErrorMessage { get; set; } = "";

        public PointSetterFilter(IPointRepository pointRepository)
        {
            this.pointRepository = pointRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            GetControllerFromContext(context);
            GetModelFromContext(context);
            SetPointsForModel(context);
            if (ErrorMessage != "")
            {
                context.Result = new ViewResult()
                {
                    ViewName = "NotFound",
                    ViewData = Controller.ViewData
                };
                Controller.ViewBag.ErrorMessage = ErrorMessage;
            }
            else
            {
                UpdateContextModel(context);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        private void GetControllerFromContext(ActionExecutingContext context)
        {
            Controller = (BaseInformationController)context.Controller;
        }

        private void GetModelFromContext(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("model"))
            {
                Model = (T)context.ActionArguments["model"]!;
            }
        }

        private void SetPointsForModel(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                Model.Points = pointRepository.GetPointsForSelectListByStructureId(Controller.Structure!.Id);
            else
            {
                var point = pointRepository.Get(Model.LocationId, Controller.Structure!.Id);
                if (point == null)
                    ErrorMessage = "The point is not found or the current user doesn't have access to this point";
                else
                    Model.Location = point;
            }
        }

        private void UpdateContextModel(ActionExecutingContext context)
        {
            context.ActionArguments["model"] = Model;
        }
    }
}
