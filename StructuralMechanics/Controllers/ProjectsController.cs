using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Utilities;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{
    [Authorize]
    public class ProjectsController : BaseController
    {
        public ProjectsController(UserManager<ApplicationUser> userManager, 
                                  IProjectService projectService, 
                                  IStructureService structureService) : base(userManager, projectService, structureService)
        {
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
        public async Task<IActionResult> Create(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    ViewBag.ErrorMessage = "User is not found";
                    return View("NotFound");
                }

                (bool isStructureValid, string errorMessage, Structure? structure) = StructureCreator.GetStructureObject(model);

                if (!isStructureValid)
                {
                    model.StructureType = null;
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
                return RedirectToAction("Overview", $"{structure!.StructureType}", new { projectId = $"{project.Id}", area = "Project" });
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

            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }
            ViewBag.ProjectId = projectId;

            ProjectViewModel model = new ProjectViewModel()
            {
                ProjectName = Project!.ProjectName,
                StructureType = Structure!.StructureType,
                ThinWalledStructureType = (Structure.StructureType == StructureType.ThinWalledStructure) 
                                            ? ((ThinWalledStructure)Structure).ThinWalledStructureType 
                                            : null
            };

            return View(model);
        }

        [HttpPost]
        [Route("Edit/{projectId}")]
        public async Task<IActionResult> Edit(string projectId, ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                await SetProjectRelatedData(projectId);
                if (!IsReady)
                {
                    ViewBag.ErrorMessage = ErrorMessage;
                    return View("NotFound");
                }

                (bool isStructureValid, string errorMessage, Structure structure) = StructureUpdater.GetUpdatedStructureObject(model, Structure!);
                if (!isStructureValid)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                    return View(model);
                }

                Project!.ProjectName = model.ProjectName;
                // If we don't update structure info there's no need for calling update structure
                structureService.UpdateStructure(structure);
                projectService.UpdateProject(Project);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [Route("Delete/{projectId}")]
        public async Task<IActionResult> Delete(string projectId)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }

            structureService.DeleteStructure(Structure!);
            projectService.DeleteProject(Project!);

            return RedirectToAction("Index", "Projects");
        }
    }
}
