using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Utilities;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{
    [Route("Project/{projectId}/[Controller]/[action]")]
    public class PointsController : BaseController
    {
        private readonly IGeometryObjectService geometryObjectService;
        private readonly IPointsService pointsService;

        public PointsController(UserManager<ApplicationUser> userManager,
                                   IProjectService projectService,
                                   IStructureService structureService,
                                   IGeometryObjectService geometryObjectService,
                                   IPointsService pointsService) : base(userManager, projectService, structureService)
        {
            this.geometryObjectService = geometryObjectService;
            this.pointsService = pointsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string projectId)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }

            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";
            ViewBag.ProjectId = projectId;
            ViewBag.StructureType = Structure!.StructureType;

            var points = pointsService.GetPointsByStructureId(Structure!.Id);
            return View(points);
        }

        [HttpGet]
        public IActionResult Create(string projectId)
        {
            ViewBag.ProjectId = projectId;
            var structure = structureService.GetStructureByProjectId(projectId);
            if (structure == null)
            {
                ViewBag.ErrorMessage = "Structure is not found";
                return View("NotFound");
            }
            ViewBag.StructureType = structure.StructureType;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string projectId, CreatePointViewModel model)
        {
            if (ModelState.IsValid)
            {
                Point point = new Point(model.X, model.Y);
                if (!point.IsPointValid())
                {
                    ModelState.AddModelError(string.Empty, "A point should have positive coordinates");
                    return View(model);
                }
                await SetProjectRelatedData(projectId);
                if (!IsReady)
                {
                    ViewBag.ErrorMessage = ErrorMessage;
                    return View("NotFound");
                }

                point.Structure = Structure!;

                geometryObjectService.AddGeometryObject(point);

                return new RedirectResult(url: $"~/Project/{Project!.Id}/Points/Index", false, false);
            }

            return View(model);
        }
    }
}
