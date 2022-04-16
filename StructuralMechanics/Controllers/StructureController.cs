using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{ 
    [Authorize]
    public abstract class StructureController : BaseController
    {
        private protected readonly IGeometryObjectService geometryObjectService;
        private protected readonly IVectorPhysicalQuantityService vectorPhysicalQuantityService;

        public StructureController(UserManager<ApplicationUser> userManager, 
                                   IProjectService projectService, 
                                   IStructureService structureService, 
                                   IGeometryObjectService geometryObjectService,
                                   IVectorPhysicalQuantityService vectorPhysicalQuantityService) : base(userManager, projectService, structureService)
        {
            this.geometryObjectService = geometryObjectService;
            this.vectorPhysicalQuantityService = vectorPhysicalQuantityService;
        }

        public abstract Task<IActionResult> Overview(string projectId);
    }
}
