using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Models;
using StructuralMechanics.Utilities;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectService projectService;
        private readonly IStructureService structureService;

        public HomeController(UserManager<ApplicationUser> userManager,
                              IProjectService projectService, 
                              IStructureService structureService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.structureService = structureService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user != null)
            {
                return View(ProjectsQuery.Query(user, projectService, structureService));
            }

            return View();
        }
    }
}
