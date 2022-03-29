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
                var projects = projectService.GetProjects(user.Id).Take(10);
                return View(projects);
            }

            return View();
        }
    }
}
