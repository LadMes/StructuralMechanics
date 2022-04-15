using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Utilities;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectService projectService;
        private readonly IStructureService structureService;

        public ProjectsController(UserManager<ApplicationUser> userManager, IProjectService projectService, 
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

            if (user == null)
            {
                ViewBag.ErrorMessage = "User is not found";
                return View("NotFound");
            }

            return View(ProjectsQuery.Query(user, projectService, structureService));
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

                (bool isStructureValid, string errorMessage, Structure? structure) = ModelValidation.IsStructureValid(model);

                if (!isStructureValid)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                    return View(model);
                }

                Project project = new Project()
                {
                    Id = Guid.NewGuid().ToString(),
                    ApplicationUser = user,
                    ProjectName = model.ProjectName,
                    Structure = structure!
                };

                projectService.AddProject(project);
                return new RedirectResult(url: $"~/Project/{project.Id}/{structure!.StructureType}", false, false);
            }

            return View(model);
        }

        [HttpGet]
        [Route("Edit/{projectId?}")]
        public async Task<IActionResult> Edit(string? projectId)
        {
            if (projectId == null)
            {
                ViewBag.ErrorMessage = "ID must be specified";
                return View("NotFound");
            }
            var user = await userManager.GetUserAsync(User);
            var project = projectService.GetProjectById(projectId);
            if (project == null)
            {
                ViewBag.ErrorMessage = "Project is not found";
                return View("NotFound");
            }
            else if (project.ApplicationUserId != user.Id)
            {
                ViewBag.ErrorMessage = "The current user doesn't have access to this project";
                return View("NotFound");
            }

            var structure = structureService.GetStructureByProjectId(projectId);
            if (structure == null)
            {
                ViewBag.ErrorMessage = "Structure is not found";
                return View("NotFound");
            }

            EditProjectViewModel model = new EditProjectViewModel()
            {
                ProjectId = projectId,
                ProjectName = project.ProjectName,
                StructureType = structure.StructureType,
                ThinWalledStructureType = (structure.StructureType == StructureType.ThinWalledStructure) 
                                            ? ((ThinWalledStructure)structure).ThinWalledStructureType 
                                            : null
            };

            return View(model);
        }

        [HttpPost]
        [Route("Edit/{projectId}")]
        public async Task<IActionResult> Edit(EditProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);

                if (user == null)
                {
                    ViewBag.ErrorMessage = "User is not found";
                    return View("NotFound");
                }
                
                var project = projectService.GetProjectById(model.ProjectId);
                if (project == null)
                {
                    ViewBag.ErrorMessage = "Project is not found";
                    return View("NotFound");
                }
                else if (project.ApplicationUserId != user.Id)
                {
                    ViewBag.ErrorMessage = "The current user doesn't have access to this project";
                    return View("NotFound");
                }

                var structure = structureService.GetStructureByProjectId(model.ProjectId);
                if (structure == null)
                {
                    ViewBag.ErrorMessage = "Structure is not found";
                    return View("NotFound");
                }

                (bool isStructureValid, string errorMessage, structure) = ModelValidation.IsStructureValid(model, structure);
                if (!isStructureValid)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                    return View(model);
                }

                project.ProjectName = model.ProjectName;
                // If we don't update structure info there's no need for calling update structure
                structureService.UpdateStructure(structure);
                projectService.UpdateProject(project);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [Route("Delete/{projectId}")]
        public async Task<IActionResult> Delete(string projectId)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                ViewBag.ErrorMessage = "User is not found";
                return View("NotFound");
            }

            var project = projectService.GetProjectById(projectId);
            if (project == null)
            {
                ViewBag.ErrorMessage = "Project is not found";
                return View("NotFound");
            }
            else if (project.ApplicationUserId != user.Id)
            {
                ViewBag.ErrorMessage = "The current user doesn't have access to this project";
                return View("NotFound");
            }

            var structure = structureService.GetStructureByProjectId(projectId);
            if (structure == null)
            {
                ViewBag.ErrorMessage = "Structure is not found";
                return View("NotFound");
            }

            structureService.DeleteStructure(structure);
            projectService.DeleteProject(project);

            return RedirectToAction("Index", "Projects");
        }
    }
}
