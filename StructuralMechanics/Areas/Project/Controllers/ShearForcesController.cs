using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    [TypeFilter(typeof(ProjectRelatedDataSetterFilter))]
    public class ShearForcesController : BaseInformationController
    {
        private readonly IVectorPhysicalQuantityRepository vectorRepository;
        private readonly IShearForceRepository forceRepository;

        public ShearForcesController(IProjectRepository projectRepository, 
                                     IStructureRepository structureRepository,
                                     IVectorPhysicalQuantityRepository vectorRepository,
                                     IShearForceRepository forceRepository) : base(projectRepository, structureRepository)
        {
            this.vectorRepository = vectorRepository;
            this.forceRepository = forceRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";
            var forces = forceRepository.GetForcesByStructureId(Structure!.Id);
            return View(forces);
        }

        [HttpGet]
        [TypeFilter(typeof(PointsSelectListGetterFilter<ShearForceViewModel>))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(PointSetterFilter<ShearForceViewModel>))]
        public IActionResult Create(ShearForceViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var force = new ShearForce(model.Magnitude, model.Location!);
            force.Structure = Structure!;
            vectorRepository.Add(force);
            return RedirectToAction("Index", "ShearForces");
        }
    }
}
