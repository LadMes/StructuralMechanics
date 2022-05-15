using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Filters
{
    public class ProjectRelatedDataSetterFilter : IAsyncActionFilter
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectRepository projectRepository;
        private readonly IStructureRepository structureRepository;
        private BaseInformationController Controller { get; set; }
        private string ErrorMessage { get; set; } = "";

        public ProjectRelatedDataSetterFilter(UserManager<ApplicationUser> userManager,
                                           IProjectRepository projectRepository,
                                           IStructureRepository structureRepository)
        {
            this.userManager = userManager;
            this.projectRepository = projectRepository;
            this.structureRepository = structureRepository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Controller = (BaseInformationController)context.Controller;
            string projectId = GetProjectId("projectId", context);
            await SetProjectRelatedData(projectId, context);
            if (ErrorMessage != "")
            {
                context.Result = new ViewResult()
                {
                    ViewName = "NotFound",
                    ViewData = Controller.ViewData
                };
                Controller.ViewBag.ErrorMessage = ErrorMessage;
                return;
            }

            await next();
        }

        private async Task SetProjectRelatedData(string projectId, ActionExecutingContext context)
        {
            await FindUser(context);
            if (Controller.ApplicationUser != null)
            {
                FindProject(Controller.ApplicationUser.Id, projectId);
                if (Controller.Project != null && ErrorMessage == "")
                {
                    FindStructure(projectId);
                }
            }
        }

        private async Task FindUser(ActionExecutingContext context)
        {
            Controller.ApplicationUser = await userManager.GetUserAsync(context.HttpContext.User);
        }

        private void FindProject(string userId, string projectId)
        {
            if (projectId != "")
            {
                Controller.Project = projectRepository.GetProjectById(projectId);
                if (Controller.Project == null)
                {
                    ErrorMessage = "Project is not found";
                }
                else if (Controller.Project.ApplicationUserId != userId)
                {
                    ErrorMessage = "The current user doesn't have access to this project";
                }
                else
                {
                    Controller.ViewBag.ProjectId = Controller.Project.Id;
                }
            }
        }

        private void FindStructure(string projectId)
        {
            Controller.Structure = structureRepository.GetStructureByProjectId(projectId);
            if (Controller.Structure == null)
            {
                ErrorMessage = "Structure is not found";
            }
            else
            {
                Controller.ViewBag.StructureType = Controller.Structure.Type;
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
