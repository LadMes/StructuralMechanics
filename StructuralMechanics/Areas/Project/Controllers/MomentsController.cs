using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.Mappers;
using StructuralMechanics.Areas.Project.ViewModels;
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

        [HttpPost]
        public IActionResult Create(MomentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var moment = new Moment(model.Magnitude);
            moment.Structure = Structure!;
            vectorRepository.Add(moment);
            return RedirectToAction("Index", "Moments");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var moment = momentRepository.Get(id, Structure!.Id);
            if (moment == null)
            {
                ViewBag.ErrorMessage = "The moment is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            var model = MomentMapper.Map(moment);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(MomentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var moment = momentRepository.Get(model.Id, Structure!.Id);
            if (moment == null)
            {
                ViewBag.ErrorMessage = "The moment is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            moment.Magnitude = model.Magnitude;
            vectorRepository.Update(moment);
            return RedirectToAction("Index", "Moments");
        }
    }
}
