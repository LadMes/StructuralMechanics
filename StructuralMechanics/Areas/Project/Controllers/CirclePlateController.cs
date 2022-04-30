using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace StructuralMechanics.Areas.Project.Controllers
{
    // For Future
    public class CirclePlateController : StructureController
    {
        public CirclePlateController(UserManager<ApplicationUser> userManager,
                                             IProjectRepository projectService,
                                             IStructureRepository structureService,
                                             ICrossSectionRepository geometryObjectService,
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
            var geometryObjects = geometryObjectService.GetCrossSectionElementsByStructureId(Structure!.Id);
            var vectors = vectorPhysicalQuantityService.GetVectorPhysicalQuantitiesByStructureId(Structure!.Id);

            return View();
        }
    }
}
