using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Utilities;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{
    [Route("Project/{projectId}/[Controller]/[action]")]
    public class PointsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectService projectService;
        private readonly IStructureService structureService;
        private readonly IGeometryObjectService geometryObjectService;
        private readonly IPointsService pointsService;

        public PointsController(UserManager<ApplicationUser> userManager,
                                   IProjectService projectService,
                                   IStructureService structureService,
                                   IGeometryObjectService geometryObjectService,
                                   IPointsService pointsService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.structureService = structureService;
            this.geometryObjectService = geometryObjectService;
            this.pointsService = pointsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string projectId)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                ViewBag.ErrorMessage = "User is not found";
                return View("NotFound");
            }
            var project = projectService.GetProjectById(projectId);
            if (project == null || project.ApplicationUserId != user.Id)
            {
                ViewBag.ErrorMessage = "User does not have access to this project";
                return View("NotFound");
            }
            ViewBag.ProjectName = $"Project: {project.ProjectName}";
            ViewBag.ProjectId = projectId;

            var structure = structureService.GetStructureByProjectId(projectId);
            if (structure == null)
            {
                ViewBag.ErrorMessage = "Structure is not found";
                return View("NotFound");
            }
            ViewBag.StructureType = structure.StructureType;

            var points = pointsService.GetPointsByStructureId(structure.Id);
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
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    ViewBag.ErrorMessage = "User is not found";
                    return View("NotFound");
                }
                var project = projectService.GetProjectById(projectId);
                if (project == null || project.ApplicationUserId != user.Id)
                {
                    ViewBag.ErrorMessage = "User does not have access to this project";
                    return View("NotFound");
                }

                var structure = structureService.GetStructureByProjectId(projectId);
                if (structure == null)
                {
                    ViewBag.ErrorMessage = "Structure is not found";
                    return View("NotFound");
                }

                point.Structure = structure;

                geometryObjectService.AddGeometryObject(point);

                return new RedirectResult(url: $"~/Project/{project.Id}/Points/Index", false, false);
            }

            return View(model);
        }
    }
}
