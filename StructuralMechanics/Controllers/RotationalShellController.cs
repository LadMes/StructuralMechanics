using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StructuralMechanics.Controllers
{
    // For Future
    [Route("Project/{projectId}/RotationalShell")]
    public class RotationalShellController : StructureController
    {
        public RotationalShellController(UserManager<ApplicationUser> userManager,
                                             IProjectService projectService,
                                             IStructureService structureService,
                                             IGeometryObjectService geometryObjectService,
                                             IVectorPhysicalQuantityService vectorPhysicalQuantityService)
                                            : base(userManager, projectService, structureService,
                                                   geometryObjectService, vectorPhysicalQuantityService) { }
        public override async Task<IActionResult> Overview(string projectId)
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
            var vectors = vectorPhysicalQuantityService.GetVectorPhysicalQuantitiesByStructureId(structure.Id);

            return View();
        }
    }
}
