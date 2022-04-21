using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Areas.Project.Controllers
{
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
        public async Task<IActionResult> Create(string projectId)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }
            ViewBag.ProjectId = projectId;
            ViewBag.StructureType = Structure!.StructureType;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string projectId, PointViewModel model)
        {
            if (ModelState.IsValid)
            {
                await SetProjectRelatedData(projectId);
                if (!IsReady)
                {
                    ViewBag.ErrorMessage = ErrorMessage;
                    return View("NotFound");
                }

                Point point = new Point(model.X, model.Y);
                point.Structure = Structure!;

                geometryObjectService.AddGeometryObject(point);

                return RedirectToAction("Index", "Points");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string projectId, int pointId)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }
            ViewBag.ProjectId = projectId;
            ViewBag.StructureType = Structure!.StructureType;

            var point = pointsService.GetPoint(pointId, Structure.Id);
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
