using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;
using StructuralMechanics.Filters;

namespace StructuralMechanics.Areas.Project.Controllers
{
    [TypeFilter(typeof(SetProjectRelatedDataFilter))]
    public class CrossSectionPartsController : BaseInformationController
    {
        private readonly ICrossSectionElementRepository crossSectionElementRepository;
        private readonly IPointRepository pointRepository;
        private readonly ICrossSectionPartRepository crossSectionPartRepository;

        public CrossSectionPartsController(IProjectRepository projectRepository, 
                                           IStructureRepository structureRepository,
                                           ICrossSectionElementRepository crossSectionElementRepository,
                                           IPointRepository pointRepository,
                                           ICrossSectionPartRepository crossSectionPartRepository) 
                                           : base(projectRepository, structureRepository)
        {
            this.crossSectionElementRepository = crossSectionElementRepository;
            this.pointRepository = pointRepository;
            this.crossSectionPartRepository = crossSectionPartRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!IsAllBaseInformationReady)
            {
                return View("NotFound");
            }

            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";

            var crossSectionParts = crossSectionPartRepository.GetCrossSectionPartsByStructureId(Structure!.Id);
            return View(crossSectionParts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!IsAllBaseInformationReady)
            {
                return View("NotFound");
            }

            var points = pointRepository.GetPointsForSelectListByStructureId(Structure!.Id);

            return View(new CrossSectionPartViewModel { Points = points });
        }

        [HttpPost]
        public IActionResult Create(CrossSectionPartViewModel model)
        {
            if (!IsAllBaseInformationReady)
            {
                return View("NotFound");
            }
            var points = pointRepository.GetPointsForSelectListByStructureId(Structure!.Id);
            model.Points = points;

            if (ModelState.IsValid)
            {
                var firstPoint = pointRepository.GetPoint(model.FirstPointId, Structure!.Id);
                var secondPoint = pointRepository.GetPoint(model.SecondPointId, Structure!.Id);
                if (firstPoint == null || secondPoint == null)
                {
                    ViewBag.ErrorMessage = "The point is not found or the current user doesn't have access to this point";
                    return View("NotFound");
                }
                model.FirstPoint = firstPoint;
                model.SecondPoint = secondPoint;
                (bool isValid, CrossSectionPart? crossSectionPart) = CrossSectionPartCreator.GetSimpleShapeObject(model);
                if (!isValid)
                {
                    ModelState.AddModelError(string.Empty, "Choose Cross-section Part Type");
                    return View(model);
                }

                crossSectionPart!.StructureId = Structure!.Id;
                crossSectionElementRepository.AddCrossSectionElement(crossSectionPart!);
                return RedirectToAction("Index", "CrossSectionParts");
            }
            model.Type = null;
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int crossSectionPartId)
        {
            if (!IsAllBaseInformationReady)
            {
                return View("NotFound");
            }

            var crossSectionPart = crossSectionPartRepository.GetCrossSectionPart(crossSectionPartId, Structure!.Id);
            if (crossSectionPart == null)
            {
                ViewBag.ErrorMessage = "The cross-section part is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            var points = pointRepository.GetPointsForSelectListByStructureId(Structure!.Id);

            CrossSectionPartViewModel model = new CrossSectionPartViewModel()
            {
                Id = crossSectionPartId,
                Type = crossSectionPart.Type,
                FirstPoint = crossSectionPart.FirstPoint,
                SecondPoint = crossSectionPart.SecondPoint,
                Thickness = crossSectionPart.Thickness,
                FirstPointId = crossSectionPart.FirstPointId,
                SecondPointId = crossSectionPart.SecondPointId,
                Points = points
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CrossSectionPartViewModel model)
        {
            if (!IsAllBaseInformationReady)
            {
                return View("NotFound");
            }
            var points = pointRepository.GetPointsForSelectListByStructureId(Structure!.Id);
            model.Points = points;
            if (ModelState.IsValid)
            {
                var crossSectionPart = crossSectionPartRepository.GetCrossSectionPart(model.Id, Structure!.Id);
                if (crossSectionPart == null)
                {
                    ViewBag.ErrorMessage = "The cross-section part is not found or the current user doesn't have access to this element";
                    return View("NotFound");
                }

                var firstPoint = pointRepository.GetPoint(model.FirstPointId, Structure!.Id);
                var secondPoint = pointRepository.GetPoint(model.SecondPointId, Structure!.Id);
                if (firstPoint == null || secondPoint == null)
                {
                    ViewBag.ErrorMessage = "The point is not found or the current user doesn't have access to this point";
                    return View("NotFound");
                }
                model.FirstPoint = firstPoint;
                model.SecondPoint = secondPoint;

                crossSectionPart.Edit(model.FirstPoint, model.SecondPoint, model.Thickness);

                crossSectionElementRepository.UpdateCrossSectionElement(crossSectionPart);

                return RedirectToAction("Index", "CrossSectionParts");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int crossSectionPartId)
        {
            if (!IsAllBaseInformationReady)
            {
                return View("NotFound");
            }
            var crossSectionPart = crossSectionPartRepository.GetCrossSectionPart(crossSectionPartId, Structure!.Id);
            if (crossSectionPart == null)
            {
                ViewBag.ErrorMessage = "The cross-section part is not found or the current user doesn't have access to this element";
                return View("NotFound");
            }

            crossSectionElementRepository.DeleteCrossSectionElement(crossSectionPart);

            return RedirectToAction("Index", "CrossSectionParts");
        }
    }
}
