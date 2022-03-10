using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Models;

namespace StructuralMechanics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //using (AppDbContext context = new AppDbContext())
            return View();
        }
    }
}
