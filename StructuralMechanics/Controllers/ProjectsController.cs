using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Models;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectService projectService;
        private readonly IStructureService<Structure> structureService;

        public ProjectsController(UserManager<ApplicationUser> userManager, IProjectService projectService, IStructureService<Structure> structureService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.structureService = structureService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                ViewBag.ErrorMessage = "User is not found";
                return View("NotFound");
            }

            var projects = projectService.GetProjects(user.Id);

            return View(projects);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectViewModel model)
        {
            if (ModelState.IsValid && model.StructureType == StructureType.ThinWalledStructure)
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    ViewBag.ErrorMessage = "User is not found";
                    return View("NotFound");
                }

                ThinWalledStructure structure = new ThinWalledStructure(model.ThinWalledStructureType);

                Project project = new Project()
                {
                    ApplicationUser = user,
                    ProjectName = model.ProjectName,
                    Structure = structure
                };

                projectService.AddProject(project);
                structureService.AddStructure(structure);

                return RedirectToAction("Index", "Projects");
            }

            ModelState.AddModelError(string.Empty, "Others types aren't supported right now");
            return View(model);
        }
    }
}
