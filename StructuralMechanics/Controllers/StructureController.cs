using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{
    [Authorize]
    [Route("Project/{projectId}")]
    public class StructureController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProjectService projectService;
        private readonly IStructureService structureService;
        private readonly IGeometryObjectService geometryObjectService;

        public StructureController(UserManager<ApplicationUser> userManager, 
                                   IProjectService projectService, 
                                   IStructureService structureService, 
                                   IGeometryObjectService geometryObjectService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.structureService = structureService;
            this.geometryObjectService = geometryObjectService;
        }

        public async Task<IActionResult> Overview(string projectId)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                ViewBag.ErrorMessage = "User is not found";
                return View("NotFound");
            }
            var project = projectService.GetProjectById(projectId);
            if (project == null || project.ApplicationUserId != user.Id)
            {
                ViewBag.ErrorMessage = "User does not have access to this project";
                return View("NotFound");
            }
            ViewBag.ProjectName = project.ProjectName;

            var structure = structureService.GetStructureByProjectId(projectId);
            if (structure == null)
            {
                ViewBag.ErrorMessage = "Structure is not found";
                return View("NotFound");
            }
            var geometryObjects = geometryObjectService.GetGeometryObjectsByStructureId(structure.Id);

            //Model should be viewmodel of concrete structure type derived from structure view model
            return View(structure);
        }


        // To-do tommorow
        //private StructureOverviewViewModel GetOverviewViewModel(StructureType structureType)
        //{
        //    return
        //}
    }
}
