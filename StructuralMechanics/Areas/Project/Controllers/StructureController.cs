using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Areas.Project.Controllers
{ 
    public abstract class StructureController : BaseInformationController
    {
        private protected readonly ICrossSectionElementRepository crossSectionElementRepository;
        private protected readonly IVectorPhysicalQuantityRepository vectorPhysicalQuantityRepository;

        public StructureController(IProjectRepository projectRepository, 
                                   IStructureRepository structureRepository, 
                                   ICrossSectionElementRepository crossSectionElementRepository,
                                   IVectorPhysicalQuantityRepository vectorPhysicalQuantityRepository) 
                                   : base(projectRepository, structureRepository)
        {
            this.crossSectionElementRepository = crossSectionElementRepository;
            this.vectorPhysicalQuantityRepository = vectorPhysicalQuantityRepository;
        }

        public abstract IActionResult Overview();
    }
}
