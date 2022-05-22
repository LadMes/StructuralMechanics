using Microsoft.AspNetCore.Mvc;

namespace StructuralMechanics.Areas.Project.Controllers
{
    public class MomentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
