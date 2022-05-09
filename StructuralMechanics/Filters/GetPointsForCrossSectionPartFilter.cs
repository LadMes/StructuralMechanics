using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Filters
{
    public class GetPointsForCrossSectionPartFilter : IActionFilter
    {
        private readonly IPointRepository pointRepository;
        private BaseInformationController Controller { get; set; }
        private CrossSectionPartViewModel Model { get; set; } = new();
        private string ErrorMessage { get; set; } = "";

        public GetPointsForCrossSectionPartFilter(IPointRepository pointRepository)
        {
            this.pointRepository = pointRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            GetControllerFromContext(context);
            GetModelFromContext(context);
            SetPointsForModel();
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
                Model = (CrossSectionPartViewModel)context.ActionArguments["model"]!;
            }
        }

        private void SetPointsForModel()
        {
            var firstPoint = pointRepository.GetPoint(Model.FirstPointId, Controller.Structure!.Id);
            var secondPoint = pointRepository.GetPoint(Model.SecondPointId, Controller.Structure!.Id);
            if (firstPoint == null || secondPoint == null)
            {
                ErrorMessage = "The point is not found or the current user doesn't have access to this point";
            }
            else
            {
                Model.FirstPoint = firstPoint;
                Model.SecondPoint = secondPoint;
            }
        }

        private void UpdateContextModel(ActionExecutingContext context)
        {
            context.ActionArguments["model"] = Model;
        }
    }
}
