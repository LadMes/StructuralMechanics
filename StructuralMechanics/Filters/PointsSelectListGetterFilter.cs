using Microsoft.AspNetCore.Mvc.Filters;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Filters
{
    public class PointsSelectListGetterFilter<T> : IResultFilter where T : PointsViewModel, new()
    {
        private readonly IPointRepository pointRepository;
        private BaseInformationController Controller { get; set; }
        private T Model { get; set; } = new();

        public PointsSelectListGetterFilter(IPointRepository pointRepository)
        {
            this.pointRepository = pointRepository;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            GetControllerFromContext(context);
            GetModelFromController();
            SetPointsForViewModel();
            UpdateContextViewModel(context);
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        private void GetControllerFromContext(ResultExecutingContext context)
        {
            Controller = (BaseInformationController)context.Controller;
        }

        private void GetModelFromController()
        {
            var model = Controller.ViewData.Model;
            if (model != null)
            {
                Model = (T)model;
            }
        }

        private void SetPointsForViewModel()
        {
            Model.Points = pointRepository.GetPointsForSelectListByStructureId(Controller.Structure!.Id);
        }

        private void UpdateContextViewModel(ResultExecutingContext context)
        {
            ((BaseInformationController)context.Controller).ViewData.Model = Model;
        }
    }
}
