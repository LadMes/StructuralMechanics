using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Filters
{
    public class SetProjectRelatedDataFilter : IAsyncActionFilter
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectRepository projectRepository;
        private readonly IStructureRepository structureRepository;
        private BaseInformationController BaseInformationController { get; set; }
        private string ErrorMessage { get; set; } = "";

        public SetProjectRelatedDataFilter(UserManager<ApplicationUser> userManager,
                                           IProjectRepository projectRepository,
                                           IStructureRepository structureRepository)
        {
            this.userManager = userManager;
            this.projectRepository = projectRepository;
            this.structureRepository = structureRepository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            BaseInformationController = (BaseInformationController)context.Controller;
            string projectId = GetProjectId("projectId", context);
            await SetProjectRelatedData(projectId, context);
            if (ErrorMessage != "")
            {
                context.Result = new ViewResult()
                {
                    ViewName = "NotFound",
                    ViewData = BaseInformationController.ViewData
                };
                BaseInformationController.ViewBag.ErrorMessage = ErrorMessage;
                return;
            }

            await next();
        }

        private async Task SetProjectRelatedData(string projectId, ActionExecutingContext context)
        {
            await FindUser(context);
            if (BaseInformationController.ApplicationUser != null)
            {
                FindProject(BaseInformationController.ApplicationUser.Id, projectId);
                if (BaseInformationController.Project != null && ErrorMessage == "")
                {
                    FindStructure(projectId);
                }
            }
        }

        private async Task FindUser(ActionExecutingContext context)
        {
            BaseInformationController.ApplicationUser = await userManager.GetUserAsync(context.HttpContext.User);
        }

        private void FindProject(string userId, string projectId)
        {
            if (projectId != "")
            {
                BaseInformationController.Project = projectRepository.GetProjectById(projectId);
                if (BaseInformationController.Project == null)
                {
                    ErrorMessage = "Project is not found";
                }
                else if (BaseInformationController.Project.ApplicationUserId != userId)
                {
                    ErrorMessage = "The current user doesn't have access to this project";
                }
                else
                {
                    BaseInformationController.ViewBag.ProjectId = BaseInformationController.Project.Id;
                }
            }
        }

        private void FindStructure(string projectId)
        {
            BaseInformationController.Structure = structureRepository.GetStructureByProjectId(projectId);
            if (BaseInformationController.Structure == null)
            {
                ErrorMessage = "Structure is not found";
            }
            else
            {
                BaseInformationController.ViewBag.StructureType = BaseInformationController.Structure.Type;
            }
        }

        private static string GetProjectId(string key, ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey(key))
                return context.ActionArguments[key]!.ToString()!;
            else if (context.RouteData.Values.ContainsKey(key))
                return context.RouteData.Values[key]!.ToString()!;

            return "";
        }
    }
}
