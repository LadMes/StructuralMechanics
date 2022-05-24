using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Controllers;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    [TypeFilter(typeof(ProjectRelatedDataSetterFilter))]
    public class MomentsController : BaseInformationController
    {
        private readonly IVectorPhysicalQuantityRepository vectorRepository;
        private readonly IMomentRepository momentRepository;

        public MomentsController(IProjectRepository projectRepository, 
                                 IStructureRepository structureRepository,
                                 IVectorPhysicalQuantityRepository vectorRepository,
                                 IMomentRepository momentRepository) : base(projectRepository, structureRepository)
        {
            this.vectorRepository = vectorRepository;
            this.momentRepository = momentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";
            var moments = momentRepository.GetMomentsByStructureId(Structure!.Id);
            return View(moments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
