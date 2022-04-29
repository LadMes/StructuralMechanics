using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StructuralMechanics.Areas.Project.Controllers
{
    // For Future
    public class RotationalShellController : StructureController
    {
        public RotationalShellController(UserManager<ApplicationUser> userManager,
                                             IProjectRepository projectService,
                                             IStructureRepository structureService,
                                             IGeometryObjectRepository geometryObjectService,
                                             IVectorPhysicalQuantityRepository vectorPhysicalQuantityService)
                                            : base(userManager, projectService, structureService,
                                                   geometryObjectService, vectorPhysicalQuantityService) { }
        public override async Task<IActionResult> Overview(string projectId)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }

            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";
            ViewBag.ProjectId = projectId;
            var geometryObjects = geometryObjectService.GetGeometryObjectsByStructureId(Structure!.Id);
            var vectors = vectorPhysicalQuantityService.GetVectorPhysicalQuantitiesByStructureId(Structure!.Id);

            return View();
        }
    }
}
