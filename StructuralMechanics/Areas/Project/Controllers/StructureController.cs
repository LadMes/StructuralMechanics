using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Areas.Project.Controllers
{ 
    [Authorize]
    public abstract class StructureController : BaseController
    {
        private protected readonly ICrossSectionRepository geometryObjectService;
        private protected readonly IVectorPhysicalQuantityRepository vectorPhysicalQuantityService;

        public StructureController(UserManager<ApplicationUser> userManager, 
                                   IProjectRepository projectService, 
                                   IStructureRepository structureService, 
                                   ICrossSectionRepository geometryObjectService,
                                   IVectorPhysicalQuantityRepository vectorPhysicalQuantityService) : base(userManager, projectService, structureService)
        {
            this.geometryObjectService = geometryObjectService;
            this.vectorPhysicalQuantityService = vectorPhysicalQuantityService;
        }

        public abstract Task<IActionResult> Overview(string projectId);
    }
}
