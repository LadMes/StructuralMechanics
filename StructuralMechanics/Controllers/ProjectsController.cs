using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Models;

namespace StructuralMechanics.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectsController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                ViewBag.Error = "User is not found";
                return View("NotFound");
            }

            var projects = user.Projects;

            return View(projects);
        }
    }
}
