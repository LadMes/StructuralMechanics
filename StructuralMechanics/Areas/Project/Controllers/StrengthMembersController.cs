using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    [TypeFilter(typeof(ProjectRelatedDataSetterFilter))]
    public class StrengthMembersController : BaseInformationController
    {
        private readonly ICrossSectionElementRepository crossSectionElementRepository;
        private readonly IStrengthMemberRepository strengthMemberRepository;

        public StrengthMembersController(IProjectRepository projectRepository, 
                                         IStructureRepository structureRepository,
                                         ICrossSectionElementRepository crossSectionElementRepository,
                                         IStrengthMemberRepository strengthMemberRepository) : base(projectRepository, structureRepository)
        {
            this.crossSectionElementRepository = crossSectionElementRepository;
            this.strengthMemberRepository = strengthMemberRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";
            var strengthMembers = strengthMemberRepository.GetStrengthMembersByStructureId(Structure!.Id);
            return View(strengthMembers);
        }

        [HttpGet]
        [TypeFilter(typeof(PointsSelectListGetterFilter<StrengthMemberViewModel>))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(StrengthMemberPointSetterFilter))]
        public IActionResult Create(StrengthMemberViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var strengthMember = new StrengthMember(model.ReductionCoefficient, model.Area, model!.Location);
            strengthMember.Structure = Structure!;
            crossSectionElementRepository.AddCrossSectionElement(strengthMember);
            return RedirectToAction("Index", "StrengthMembers");
        }
    }
}
