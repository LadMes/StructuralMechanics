using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

            var projects = projectService.GetProjects(user.Id).Take(10);

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
                    Id = Guid.NewGuid().ToString(),
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

        [HttpGet]
        [Route("Edit/{projectId}")]
        public async Task<IActionResult> Edit(string projectId)
        {
            var user = await userManager.GetUserAsync(User);
            var project = projectService.GetProjectById(projectId);
            if (project == null)
            {
                ViewBag.ErrorMessage = "Project is not found";
                return View("NotFound");
            }
            else if (project.ApplicationUser.Id != user.Id)
            {
                ViewBag.ErrorMessage = "The current user doesn't have access to this project";
                return View("NotFound");
            }

            EditProjectViewModel model = new EditProjectViewModel()
            {
                ProjectId = projectId,
                ProjectName = project.ProjectName,
                StructureType = project.StructureType,
                ThinWalledStructureType = (project.StructureType == StructureType.ThinWalledStructure) 
                                            ? ((ThinWalledStructure)structureService.GetStructureByProjectId(projectId)).ThinWalledStructureType : null
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
                if (project.ApplicationUser.Id != user.Id)
                {
                    ViewBag.ErrorMessage = "The current user doesn't have access to this project";
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
                        //structure = new ThinWalledStructure(model.ThinWalledStructureType.Value);
                        structure = structureService.GetStructureByProjectId(model.ProjectId);
                        ((ThinWalledStructure)structure).ThinWalledStructureType = model.ThinWalledStructureType.Value;
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

                project.ProjectName = model.ProjectName;
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
            if (project.ApplicationUser.Id != user.Id)
            {
                ViewBag.ErrorMessage = "The current user doesn't have access to this project";
                return View("NotFound");
            }

            structureService.DeleteStructureById(project.StructureId);
            projectService.DeleteProjectById(project.Id);

            return RedirectToAction("Index", "Projects");
        }
    }
}
