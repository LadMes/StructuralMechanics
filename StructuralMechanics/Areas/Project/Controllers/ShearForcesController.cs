using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.Mappers;
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

        [HttpGet]
        [TypeFilter(typeof(PointsSelectListGetterFilter<ShearForceViewModel>))]
        public IActionResult Edit(int id)
        {
            var force = forceRepository.Get(id, Structure!.Id);
            if (force == null)
            {
                ViewBag.ErrorMessage = "The shear force is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            var model = ShearForceMapper.Map(force);
            return View(model);
        }

        [HttpPost]
        [TypeFilter(typeof(PointSetterFilter<ShearForceViewModel>))]
        public IActionResult Edit(ShearForceViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var force = forceRepository.Get(model.Id, Structure!.Id);
            if (force == null)
            {
                ViewBag.ErrorMessage = "The shear force is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            force.Magnitude = model.Magnitude;
            force.Location = model.Location!;
            vectorRepository.Update(force);
            return RedirectToAction("Index", "ShearForces");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var force = forceRepository.Get(id, Structure!.Id);
            if (force == null)
            {
                ViewBag.ErrorMessage = "The shear force is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            vectorRepository.Delete(force);
            return RedirectToAction("Index", "ShearForces");
        }
    }
}
