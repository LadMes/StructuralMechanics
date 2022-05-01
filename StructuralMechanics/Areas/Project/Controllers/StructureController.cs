using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Areas.Project.Controllers
{ 
    [Authorize]
    public abstract class StructureController : BaseController
    {
        private protected readonly ICrossSectionElementRepository crossSectionElementRepository;
        private protected readonly IVectorPhysicalQuantityRepository vectorPhysicalQuantityRepository;

        public StructureController(UserManager<ApplicationUser> userManager, 
                                   IProjectRepository projectRepository, 
                                   IStructureRepository structureRepository, 
                                   ICrossSectionElementRepository crossSectionElementRepository,
                                   IVectorPhysicalQuantityRepository vectorPhysicalQuantityRepository) 
                                   : base(userManager, projectRepository, structureRepository)
        {
            this.crossSectionElementRepository = crossSectionElementRepository;
            this.vectorPhysicalQuantityRepository = vectorPhysicalQuantityRepository;
        }

        public abstract Task<IActionResult> Overview(string projectId);
    }
}
