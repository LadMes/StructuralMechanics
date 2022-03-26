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
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    ViewBag.ErrorMessage = "User is not found";
                    return View("NotFound");
                }

                Structure structure;

                if (model.StructureType == StructureType.ThinWalledStructure)
                {
                    if (model.ThinWalledStructureType == null)
                    {
                        ModelState.AddModelError(string.Empty, "Select Thin-walled Structure Type");
                        return View(model);
                    }
                    else if (model.ThinWalledStructureType == ThinWalledStructureType.OneTimeClosed)
                    {
                        ModelState.AddModelError(string.Empty, "One-time closed Thin-walled Structure type is not supported right now");
                        return View(model);
                    }
                    else
                    {
                        structure = new ThinWalledStructure(model.ThinWalledStructureType.Value);
                    }
                }
                else if (model.StructureType == StructureType.CirclePlate)
                {
                    ModelState.AddModelError(string.Empty, "Others types aren't supported right now");
                    return View(model);

                    //For Future
                    //structure = new CirclePlate();
                }
                else if (model.StructureType == StructureType.RotationalShell)
                {
                    ModelState.AddModelError(string.Empty, "Others types aren't supported right now");
                    return View(model);

                    //For Future
                    //structure = new RotationalShell();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Select Structure Type");
                    return View(model);
                }

                Project project = new Project()
                {
                    ApplicationUser = user,
                    ProjectName = model.ProjectName,
                    StructureType = model.StructureType,
                    Structure = structure,
                };

                projectService.AddProject(project);

                return RedirectToAction("Index", "Projects");
            }

            return View(model);
        }
    }
}
