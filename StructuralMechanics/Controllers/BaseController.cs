using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StructuralMechanics.Controllers
{
    public abstract class BaseController : Controller
    {
        private protected readonly UserManager<ApplicationUser> userManager;
        private protected readonly IProjectRepository projectRepository;
        private protected readonly IStructureRepository structureRepository;

        private protected ApplicationUser? ApplicationUser { get; private set; }
        private protected Project? Project { get; set; }
        private protected Structure? Structure { get; set; }
        private protected bool IsReady { get; private set; } = false;
        private protected string ErrorMessage { get; private set; } = "";

        public BaseController(UserManager<ApplicationUser> userManager,
                              IProjectRepository projectRepository,
                              IStructureRepository structureRepository)
        {
            this.userManager = userManager;
            this.projectRepository = projectRepository;
            this.structureRepository = structureRepository;
        }

        [NonAction]
        protected async Task SetProjectRelatedData(string projectId)
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
                        ViewBag.StructureType = Structure.Type;
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
            Project = projectRepository.GetProjectById(projectId);
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
            Structure = structureRepository.GetStructureByProjectId(projectId);
            if (Structure == null)
            {
                ErrorMessage = "Structure is not found";
            }
        }
    }
}
