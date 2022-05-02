using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    [Authorize]
    [TypeFilter(typeof(SetProjectRelatedDataFilter))]
    public class PointsController : BaseInformationController
    {
        private readonly ICrossSectionElementRepository crossSectionElementRepository;
        private readonly IPointRepository pointsRepository;

        public PointsController(UserManager<ApplicationUser> userManager,
                                   IProjectRepository projectRepository,
                                   IStructureRepository structureRepository,
                                   ICrossSectionElementRepository crossSectionElementRepository,
                                   IPointRepository pointsRepository) : base(userManager, projectRepository, structureRepository)
        {
            this.crossSectionElementRepository = crossSectionElementRepository;
            this.pointsRepository = pointsRepository;
        }

        [HttpGet]
        public IActionResult Index(string projectId)
        {
            if (!IsReady)
            {
                return View("NotFound");
            }

            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";

            var points = pointsRepository.GetPointsByStructureId(Structure!.Id);
            return View(points);
        }

        [HttpGet]
        public IActionResult Create(string projectId)
        {
            if (!IsReady)
            {
                return View("NotFound");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(string projectId, PointViewModel model)
        {
            if (!IsReady)
            {
                return View("NotFound");
            }

            if (ModelState.IsValid)
            {
                Point point = new Point(model.X, model.Y);
                point.Structure = Structure!;

                crossSectionElementRepository.AddCrossSectionElement(point);

                return RedirectToAction("Index", "Points");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(string projectId, int pointId)
        {
            if (!IsReady)
            {
                return View("NotFound");
            }

            var point = pointsRepository.GetPoint(pointId, Structure!.Id);
            if (point == null)
            {
                ViewBag.ErrorMessage = "The point is not found or the current user doesn't have access to this point";
                return View("NotFound");
            }

            return View(new PointViewModel() { X = point.X, Y = point.Y });
        }

        //HttpPost for Edit and Delete will be added after completing the Create action for Simple Shapes and Strength Members
    }
}
