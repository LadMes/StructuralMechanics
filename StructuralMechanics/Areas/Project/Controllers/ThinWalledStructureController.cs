using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    public class ThinWalledStructureController : StructureController
    {
        public ThinWalledStructureController(IProjectRepository projectRepository,
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

            return View(new ThinWalledStructureOverviewViewModel(crossSectionElements, vectors));
        }
    }
}
