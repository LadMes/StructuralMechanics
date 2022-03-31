using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Models;

namespace StructuralMechanics.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IProjectService projectService;

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                                IProjectService projectService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user != null)
            {
                var projects = projectService.GetProjects(user.Id);
                //.Where(p => p.ApplicationUser.Id == userId)
                //                   .Join(context.Structures,
                //                         project => project.Id,
                //                         structure => structure.ProjectId,
                //                         (project, structure) => new ProjectsViewModel()
                //                         {
                //                             ProjectId = project.Id,
                //                             ProjectName = project.ProjectName,
                //                             StructureType = structure.StructureType,
                //                             StructureId = structure.Id,
                //                         });
                return View(projects);
            }

            return View();
        }
    }
}
