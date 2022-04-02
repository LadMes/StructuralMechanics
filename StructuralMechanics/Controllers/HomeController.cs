using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Models;
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
                var projects = projectService.GetProjects(user.Id).Select(p => new { p.Id, p.ProjectName });
                var structures = structureService.GetAllStructures().Select(s => new {s.Id, s.ProjectId, s.StructureType});

                var query = projects.Join(structures,
                                          project => project.Id,
                                          structure => structure.ProjectId,
                                          (project, structure) => new ProjectsViewModel()
                                          {
                                              ProjectId = project.Id,
                                              ProjectName = project.ProjectName,
                                              StructureType = structure.StructureType,
                                              StructureId = structure.Id,
                                          }).Take(10);
                return View(query);
            }

            return View();
        }
    }
}
