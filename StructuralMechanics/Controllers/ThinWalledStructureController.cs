using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{
    [Route("Project/{projectId}/[Controller]")]
    public class ThinWalledStructureController : StructureController
    {
        public ThinWalledStructureController(UserManager<ApplicationUser> userManager,
                                             IProjectService projectService,
                                             IStructureService structureService,
                                             IGeometryObjectService geometryObjectService,
                                             IVectorPhysicalQuantityService vectorPhysicalQuantityService) 
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

            return View(new ThinWalledStructureOverviewViewModel(geometryObjects, vectors));
        }
    }
}
