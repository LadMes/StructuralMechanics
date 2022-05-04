using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    // For Future
    public class RotationalShellController : StructureController
    {
        public RotationalShellController(IProjectRepository projectRepository,
                                         IStructureRepository structureRepository,
                                         ICrossSectionElementRepository crossSectionElementRepository,
                                         IVectorPhysicalQuantityRepository vectorPhysicalQuantityRepository)
                                         : base(projectRepository, structureRepository,
                                                crossSectionElementRepository, vectorPhysicalQuantityRepository) { }

        [TypeFilter(typeof(SetProjectRelatedDataFilter))]
        public override IActionResult Overview()
        {
            if (!IsAllBaseInformationReady)
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
