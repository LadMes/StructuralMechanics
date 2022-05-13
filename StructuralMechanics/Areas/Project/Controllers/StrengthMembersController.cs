using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.Mappers;
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

            var strengthMember = new StrengthMember(model.ReductionCoefficient, model.Area, model.Location!);
            strengthMember.Structure = Structure!;
            crossSectionElementRepository.AddCrossSectionElement(strengthMember);
            return RedirectToAction("Index", "StrengthMembers");
        }

        [HttpGet]
        [TypeFilter(typeof(PointsSelectListGetterFilter<StrengthMemberViewModel>))]
        public IActionResult Edit(int id)
        {
            var strengthMember = strengthMemberRepository.GetStrengthMember(id, Structure!.Id);
            if (strengthMember == null)
            {
                ViewBag.ErrorMessage = "The strength member is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            var model = StrengthMemberMapper.Map(strengthMember);
            return View(model);
        }

        [HttpPost]
        [TypeFilter(typeof(StrengthMemberPointSetterFilter))]
        public IActionResult Edit(StrengthMemberViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var strengthMember = strengthMemberRepository.GetStrengthMember(model.Id, Structure!.Id);
            if (strengthMember == null)
            {
                ViewBag.ErrorMessage = "The strength member is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            strengthMember.Edit(model.ReductionCoefficient, model.Area, model.Location!);
            crossSectionElementRepository.UpdateCrossSectionElement(strengthMember);
            return RedirectToAction("Index", "StrengthMembers");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var strengthMember = strengthMemberRepository.GetStrengthMember(id, Structure!.Id);
            if (strengthMember == null)
            {
                ViewBag.ErrorMessage = "The strength member is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            crossSectionElementRepository.DeleteCrossSectionElement(strengthMember);
            return RedirectToAction("Index", "StrengthMembers");
        }
    }
}
