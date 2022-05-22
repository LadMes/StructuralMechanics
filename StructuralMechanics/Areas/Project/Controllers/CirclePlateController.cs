using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    // For Future
    public class CirclePlateController : StructureController
    {
        public CirclePlateController(IProjectRepository projectRepository,
                                     IStructureRepository structureRepository,
                                     ICrossSectionElementRepository crossSectionElementRepository,
                                     IVectorPhysicalQuantityRepository vectorPhysicalQuantityRepository)
                                     : base(projectRepository, structureRepository,
                                            crossSectionElementRepository, vectorPhysicalQuantityRepository) { }

        [TypeFilter(typeof(ProjectRelatedDataSetterFilter))]
        public override IActionResult Overview()
        {
            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";

            var crossSectionElements = crossSectionElementRepository.GetElementsByStructureId(Structure!.Id);
            var vectors = vectorPhysicalQuantityRepository.GetQuantitiesByStructureId(Structure!.Id);

            return View();
        }
    }
}
