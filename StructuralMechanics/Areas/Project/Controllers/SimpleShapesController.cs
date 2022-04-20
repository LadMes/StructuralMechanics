using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Areas.Project.Controllers
{
    public class SimpleShapesController : BaseController
    {
        private readonly IPointsService pointsService;
        private readonly ISimpleShapesService simpleShapesService;

        public SimpleShapesController(UserManager<ApplicationUser> userManager, 
                                      IProjectService projectService, 
                                      IStructureService structureService,
                                      IPointsService pointsService,
                                      ISimpleShapesService simpleShapesService) : base(userManager, projectService, structureService)
        {
            this.pointsService = pointsService;
            this.simpleShapesService = simpleShapesService;
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

            var simpleShapes = simpleShapesService.GetSimpleShapesByStructureId(Structure!.Id);
            return View(simpleShapes);
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

            var points = pointsService.GetPointsByStructureId(Structure!.Id);

            return View(new SimpleShapeViewModel { Points = points });
        }
    }
}
