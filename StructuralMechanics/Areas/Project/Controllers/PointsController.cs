using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    [TypeFilter(typeof(ProjectRelatedDataSetterFilter))]
    public class PointsController : BaseInformationController
    {
        private readonly ICrossSectionElementRepository crossSectionElementRepository;
        private readonly IPointRepository pointsRepository;

        public PointsController(IProjectRepository projectRepository,
                                IStructureRepository structureRepository,
                                ICrossSectionElementRepository crossSectionElementRepository,
                                IPointRepository pointsRepository) : base(projectRepository, structureRepository)
        {
            this.crossSectionElementRepository = crossSectionElementRepository;
            this.pointsRepository = pointsRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";

            var points = pointsRepository.GetPointsByStructureId(Structure!.Id);
            return View(points);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PointViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Point point = new Point(model.X, model.Y);
            point.Structure = Structure!;
            crossSectionElementRepository.AddCrossSectionElement(point);
            return RedirectToAction("Index", "Points");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var point = pointsRepository.GetPoint(id, Structure!.Id);
            if (point == null)
            {
                ViewBag.ErrorMessage = "The point is not found or the current user doesn't have access to this point";
                return View("NotFound");
            }

            return View(new PointViewModel() { X = point.X, Y = point.Y });
        }

        [HttpPost]
        [TypeFilter(typeof(PointChangedListenersFetcherFilter))]
        public IActionResult Edit(PointViewModel model, List<IPointChangedListener> listeners)
        {
            if (!ModelState.IsValid)
                return View(model);

            var point = pointsRepository.GetPoint(model.Id, Structure!.Id);
            if (point == null)
            {
                ViewBag.ErrorMessage = "The point is not found or the current user doesn't have access to this point";
                return View("NotFound");
            }

            point.AddEventListeners(listeners);
            point.Edit(model.X, model.Y);
            crossSectionElementRepository.UpdateCrossSectionElement(point);
            return RedirectToAction("Index", "Points");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            // ...
            return RedirectToAction("Index", "Points");
        }
    }
}
