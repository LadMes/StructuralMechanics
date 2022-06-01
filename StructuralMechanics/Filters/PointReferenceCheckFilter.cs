using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Filters
{
    public class PointReferenceCheckFilter : IActionFilter
    {
        private readonly IPointRepository pointRepository;
        private readonly ICrossSectionPartRepository crossSectionPartRepository;
        private readonly IStrengthMemberRepository strengthMemberRepository;
        private BaseInformationController Controller { get; set; }
        private Point Model { get; set; }
        private List<IPointChangedListener> Listeners { get; set; } = new List<IPointChangedListener>();

        public PointReferenceCheckFilter(IPointRepository pointRepository,
                                         ICrossSectionPartRepository crossSectionPartRepository,
                                         IStrengthMemberRepository strengthMemberRepository)
        {
            this.pointRepository = pointRepository;
            this.crossSectionPartRepository = crossSectionPartRepository;
            this.strengthMemberRepository = strengthMemberRepository;
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            // To-Do: Repeatable code. Changes will appear in the next update
            GetControllerFromContext(context);
            GetPointByIdFromContext(context);
            AddListeners();
            if (Listeners.Count > 0)
                context.ModelState.AddModelError("PointError", $"The Point is referenced by {Listeners.Count} elements. " +
                                                               $"Change the point for these elements and then try delete");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
 
        }

        private void GetControllerFromContext(ActionExecutingContext context)
        {
            Controller = (BaseInformationController)context.Controller;
        }

        private void GetPointByIdFromContext(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("id"))
            {
                int id = (int)context.ActionArguments["id"]!;
                var model = pointRepository.Get(id, Controller.Structure!.Id);
                if (model == null)
                {
                    context.Result = new ViewResult()
                    {
                        ViewName = "NotFound",
                        ViewData = Controller.ViewData
                    };
                    Controller.ViewBag.ErrorMessage = "The point is not found or the current user doesn't have access to this point";
                }
                else
                    Model = model; 
            }
        }

        private void AddListeners()
        {
            AddCrossSectionPartsListeners();
            AddStrengthMembersListeners();
        }

        private void AddCrossSectionPartsListeners()
        {
            Listeners.AddRange(crossSectionPartRepository.GetPartsByStructureId(Controller.Structure!.Id)
                                                         .Where(p => p.FirstPointId == Model.Id || p.SecondPointId == Model.Id));
        }

        private void AddStrengthMembersListeners()
        {
            Listeners.AddRange(strengthMemberRepository.GetStrengthMembersByStructureId(Controller.Structure!.Id)
                                                       .Where(sm => sm.LocationId == Model.Id));
        }
    }
}
