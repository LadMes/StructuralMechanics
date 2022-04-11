using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StructuralMechanics.Controllers
{
    [Route("Project/{projectId}/Points")]
    public class PointsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectService projectService;
        private readonly IStructureService structureService;
        private readonly IPointsService pointsService;

        public PointsController(UserManager<ApplicationUser> userManager,
                                   IProjectService projectService,
                                   IStructureService structureService,
                                   IPointsService pointsService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.structureService = structureService;
            this.pointsService = pointsService;
        }

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

            var points = pointsService.GetPointsByStructureId(structure.Id);
            return View(points);
        }
    }
}
