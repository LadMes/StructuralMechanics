using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    [TypeFilter(typeof(SetProjectRelatedDataFilter))]
    public class StrengthMembersController : BaseInformationController
    {
        private readonly IStrengthMemberRepository strengthMemberRepository;

        public StrengthMembersController(IProjectRepository projectRepository, 
                                         IStructureRepository structureRepository,
                                         IStrengthMemberRepository strengthMemberRepository) : base(projectRepository, structureRepository)
        {
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
        [TypeFilter(typeof(GetPointsForViewModelFilter<StrengthMemberViewModel>))]
        public IActionResult Create()
        {
            return View();
        }
    }
}
