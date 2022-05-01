using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Utilities;

namespace StructuralMechanics.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserManager<ApplicationUser> userManager,
                              IProjectRepository projectRepository, 
                              IStructureRepository structureRepository) : base(userManager, projectRepository, structureRepository)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user != null)
            {
                return View(ProjectsQuery.Query(user, projectRepository, structureRepository));
            }

            return View();
        }
    }
}
