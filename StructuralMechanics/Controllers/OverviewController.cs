using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StructuralMechanics.Controllers
{
    [Authorize]
    [Route("Structure/{structureId}")]
    public class OverviewController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectService projectService;
        private readonly IStructureService structureService;

        public OverviewController(UserManager<ApplicationUser> userManager, IProjectService projectService, IStructureService structureService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.structureService = structureService;
        }

        public async Task<IActionResult> Index(int structureId)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                ViewBag.ErrorMessage = "User is not found";
                return View("NotFound");
            }
            var structure = structureService.GetStructureByStructureId(structureId);
            if (structure == null)
            {
                ViewBag.ErrorMessage = "Structure is not found";
                return View("NotFound");
            }
            var project = projectService.GetProjectById(structure.ProjectId);
            if (project == null || project.ApplicationUser.Id != user.Id)
            {
                ViewBag.ErrorMessage = "User does not have access to this project";
                return View("NotFound");
            }

            return View();
        }
    }
}
