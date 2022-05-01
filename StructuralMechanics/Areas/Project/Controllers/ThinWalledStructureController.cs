using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;

namespace StructuralMechanics.Areas.Project.Controllers
{
    public class ThinWalledStructureController : StructureController
    {
        public ThinWalledStructureController(UserManager<ApplicationUser> userManager,
                                             IProjectRepository projectRepository,
                                             IStructureRepository structureRepository,
                                             ICrossSectionElementRepository crossSectionElementRepository,
                                             IVectorPhysicalQuantityRepository vectorPhysicalQuantityRepository) 
                                            : base(userManager, projectRepository, structureRepository,
                                                   crossSectionElementRepository, vectorPhysicalQuantityRepository) { }

        public override async Task<IActionResult> Overview(string projectId)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }

            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";

            var crossSectionElements = crossSectionElementRepository.GetCrossSectionElementsByStructureId(Structure!.Id);
            var vectors = vectorPhysicalQuantityRepository.GetVectorPhysicalQuantitiesByStructureId(Structure!.Id);

            return View(new ThinWalledStructureOverviewViewModel(crossSectionElements, vectors));
        }
    }
}
