using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StructuralMechanics.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        public ProjectsController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
