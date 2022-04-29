using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StructuralMechanics.Controllers
{
    public abstract class BaseController : Controller
    {
        private protected readonly UserManager<ApplicationUser> userManager;
        private protected readonly IProjectRepository projectService;
        private protected readonly IStructureRepository structureService;

        private protected ApplicationUser? ApplicationUser { get; private set; }
        private protected Project? Project { get; set; }
        private protected Structure? Structure { get; set; }
        private protected bool IsReady { get; private set; } = false;
        private protected string ErrorMessage { get; private set; } = "";

        public BaseController(UserManager<ApplicationUser> userManager,
                              IProjectRepository projectService,
                              IStructureRepository structureService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.structureService = structureService;
        }

        [NonAction]
        public async Task SetProjectRelatedData(string projectId)
        {
            await FindUser();
            if (ApplicationUser != null)
            {
                FindProject(ApplicationUser.Id, projectId);
                if (Project != null && ErrorMessage == "")
                {
                    FindStructure(projectId);
                    if (Structure != null)
                    {
                        IsReady = true;
                        ViewBag.ProjectId = Project.Id;
                        ViewBag.StructureType = Structure.StructureType;
                    }
                }
            }
        }
        [NonAction]
        private async Task FindUser()
        {
            ApplicationUser = await userManager.GetUserAsync(User);
            if (User == null)
            {
                ErrorMessage = "User is not found";
            }
        }
        [NonAction]
        private void FindProject(string userId, string projectId)
        {
            Project = projectService.GetProjectById(projectId);
            if (Project == null)
            {
                ErrorMessage = "Project is not found";
            }
            else if (Project.ApplicationUserId != userId)
            {
                ErrorMessage = "The current user doesn't have access to this project";
            }
        }
        [NonAction]
        private void FindStructure(string projectId)
        {
            Structure = structureService.GetStructureByProjectId(projectId);
            if (Structure == null)
            {
                ErrorMessage = "Structure is not found";
            }
        }
    }
}
