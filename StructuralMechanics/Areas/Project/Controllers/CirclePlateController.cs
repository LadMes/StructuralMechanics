using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    // For Future
    public class CirclePlateController : StructureController
    {
        public CirclePlateController(UserManager<ApplicationUser> userManager,
                                             IProjectRepository projectRepository,
                                             IStructureRepository structureRepository,
                                             ICrossSectionElementRepository crossSectionElementRepository,
                                             IVectorPhysicalQuantityRepository vectorPhysicalQuantityRepository)
                                            : base(userManager, projectRepository, structureRepository,
                                                   crossSectionElementRepository, vectorPhysicalQuantityRepository) { }

        [TypeFilter(typeof(SetProjectRelatedDataFilter))]
        public override IActionResult Overview(string projectId)
        {
            if (!IsReady)
            {
                return View("NotFound");
            }

            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";

            var crossSectionElements = crossSectionElementRepository.GetCrossSectionElementsByStructureId(Structure!.Id);
            var vectors = vectorPhysicalQuantityRepository.GetVectorPhysicalQuantitiesByStructureId(Structure!.Id);

            return View();
        }
    }
}
