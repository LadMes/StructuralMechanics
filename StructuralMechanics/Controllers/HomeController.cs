using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Filters;
using StructuralMechanics.Utilities;

namespace StructuralMechanics.Controllers
{
    public class HomeController : BaseInformationController
    {
        public HomeController(IProjectRepository projectRepository, 
                              IStructureRepository structureRepository) : base(projectRepository, structureRepository)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [TypeFilter(typeof(SetProjectRelatedDataFilter))]
        public IActionResult Index()
        {
            if (ApplicationUser != null)
            {
                return View(ProjectsQuery.Query(ApplicationUser, projectRepository, structureRepository));
            }

            return View();
        }
    }
}
