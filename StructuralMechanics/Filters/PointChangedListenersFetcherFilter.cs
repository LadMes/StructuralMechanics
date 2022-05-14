using Microsoft.AspNetCore.Mvc.Filters;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Filters
{
    public class PointChangedListenersFetcherFilter : IActionFilter
    {
        private readonly ICrossSectionElementRepository crossSectionElementRepository;
        private readonly ICrossSectionPartRepository crossSectionPartRepository;
        private readonly IStrengthMemberRepository strengthMemberRepository;
        private BaseInformationController Controller { get; set; }
        private PointViewModel Model { get; set; } = new();
        private List<IPointChangedListener> Listeners { get; set; } = new List<IPointChangedListener>();

        public PointChangedListenersFetcherFilter(ICrossSectionElementRepository crossSectionElementRepository,
                                                  ICrossSectionPartRepository crossSectionPartRepository,
                                                  IStrengthMemberRepository strengthMemberRepository)
        {
            this.crossSectionElementRepository = crossSectionElementRepository;
            this.crossSectionPartRepository = crossSectionPartRepository;
            this.strengthMemberRepository = strengthMemberRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            GetControllerFromContext(context);
            GetModelFromContext(context);
            AddListeners();
            SetListenersActionArgument(context);
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
                Model = (PointViewModel)context.ActionArguments["model"]!;
            }
        }

        private void AddListeners()
        {
            AddCrossSectionPartsListeners();
            AddStrengthMembersListeners();
        }

        private void AddCrossSectionPartsListeners()
        {
            Listeners.AddRange(crossSectionPartRepository.GetCrossSectionPartsByStructureId(Controller.Structure!.Id)
                                                  .Where(p => p.FirstPointId == Model.Id || p.SecondPointId == Model.Id));
        }

        private void AddStrengthMembersListeners()
        {
            Listeners.AddRange(strengthMemberRepository.GetStrengthMembersByStructureId(Controller.Structure!.Id)
                                                       .Where(sm => sm.LocationId == Model.Id));
        }

        private void SetListenersActionArgument(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("listeners"))
            {
                context.ActionArguments["listeners"] = Listeners;
            }
        }
    }
}
