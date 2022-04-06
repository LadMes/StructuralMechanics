using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{ 
    [Authorize]
    public abstract class StructureController : Controller
    {
        private protected readonly UserManager<ApplicationUser> userManager;
        private protected readonly IProjectService projectService;
        private protected readonly IStructureService structureService;
        private protected readonly IGeometryObjectService geometryObjectService;
        private protected readonly IVectorPhysicalQuantityService vectorPhysicalQuantityService;

        public StructureController(UserManager<ApplicationUser> userManager, 
                                   IProjectService projectService, 
                                   IStructureService structureService, 
                                   IGeometryObjectService geometryObjectService,
                                   IVectorPhysicalQuantityService vectorPhysicalQuantityService)
        {
            this.userManager = userManager;
            this.projectService = projectService;
            this.structureService = structureService;
            this.geometryObjectService = geometryObjectService;
            this.vectorPhysicalQuantityService = vectorPhysicalQuantityService;
        }

        public abstract Task<IActionResult> Overview(string projectId);
    }
}
