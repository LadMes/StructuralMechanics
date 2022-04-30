using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Areas.Project.Controllers
{
    [Authorize]
    public class CrossSectionPartsController : BaseController
    {
        private readonly ICrossSectionRepository geometryObjectService;
        private readonly IPointRepository pointsService;
        private readonly ICrossSectionPartRepository simpleShapesService;

        public CrossSectionPartsController(UserManager<ApplicationUser> userManager, 
                                      IProjectRepository projectService, 
                                      IStructureRepository structureService,
                                      ICrossSectionRepository geometryObjectService,
                                      IPointRepository pointsService,
                                      ICrossSectionPartRepository simpleShapesService) : base(userManager, projectService, structureService)
        {
            this.geometryObjectService = geometryObjectService;
            this.pointsService = pointsService;
            this.simpleShapesService = simpleShapesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string projectId)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }

            ViewBag.ProjectName = $"Project: {Project!.ProjectName}";
            //ViewBag.ProjectId = projectId;
            //ViewBag.Type = Structure!.Type;

            var simpleShapes = simpleShapesService.GetCrossSectionPartsByStructureId(Structure!.Id);
            return View(simpleShapes);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string projectId)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }
            //ViewBag.ProjectId = projectId;
            //ViewBag.Type = Structure!.Type;

            var points = pointsService.GetPointsForSelectListByStructureId(Structure!.Id);

            return View(new CrossSectionPartViewModel { Points = points });
        }

        [HttpPost]
        public async Task<IActionResult> Create(string projectId, CrossSectionPartViewModel model)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }
            var points = pointsService.GetPointsForSelectListByStructureId(Structure!.Id);
            model.Points = points;
            if (ModelState.IsValid)
            {
                var firstPoint = pointsService.GetPoint(model.FirstPointId, Structure!.Id);
                var secondPoint = pointsService.GetPoint(model.SecondPointId, Structure!.Id);
                if (firstPoint == null || secondPoint == null)
                {
                    ViewBag.ErrorMessage = "The point is not found or the current user doesn't have access to this point";
                    return View("NotFound");
                }
                model.FirstPoint = firstPoint;
                model.SecondPoint = secondPoint;
                (bool isValid, CrossSectionPart? simpleShape) = CrossSectionPartCreator.GetSimpleShapeObject(model);
                if (!isValid)
                {
                    ModelState.AddModelError(string.Empty, "Choose Geometry Type");
                    return View(model);
                }

                simpleShape!.StructureId = Structure!.Id;
                geometryObjectService.AddCrossSectionElement(simpleShape!);
                return RedirectToAction("Index", "SimpleShapes");
            }
            model.Type = null;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string projectId, int simpleShapeId)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }
            ViewBag.ProjectId = projectId;
            ViewBag.StructureType = Structure!.Type;

            var simpleShape = simpleShapesService.GetCrossSectionPart(simpleShapeId, Structure!.Id);
            if (simpleShape == null)
            {
                ViewBag.ErrorMessage = "The shape is not found or the current user doesn't have access to this shape";
                return View("NotFound");
            }

            var points = pointsService.GetPointsForSelectListByStructureId(Structure!.Id);

            CrossSectionPartViewModel model = new CrossSectionPartViewModel()
            {
                ShapeId = simpleShapeId,
                Type = simpleShape.Type,
                FirstPoint = simpleShape.FirstPoint,
                SecondPoint = simpleShape.SecondPoint,
                Thickness = simpleShape.Thickness,
                FirstPointId = simpleShape.FirstPointId,
                SecondPointId = simpleShape.SecondPointId,
                Points = points
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string projectId, CrossSectionPartViewModel model)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }
            var points = pointsService.GetPointsForSelectListByStructureId(Structure!.Id);
            model.Points = points;
            if (ModelState.IsValid)
            {
                var simpleShape = simpleShapesService.GetCrossSectionPart(model.ShapeId, Structure!.Id);
                if (simpleShape == null)
                {
                    ViewBag.ErrorMessage = "The shape is not found or the current user doesn't have access to this shape";
                    return View("NotFound");
                }

                var firstPoint = pointsService.GetPoint(model.FirstPointId, Structure!.Id);
                var secondPoint = pointsService.GetPoint(model.SecondPointId, Structure!.Id);
                if (firstPoint == null || secondPoint == null)
                {
                    ViewBag.ErrorMessage = "The point is not found or the current user doesn't have access to this point";
                    return View("NotFound");
                }
                model.FirstPoint = firstPoint;
                model.SecondPoint = secondPoint;

                simpleShape.Edit(model.FirstPoint, model.SecondPoint, model.Thickness);

                geometryObjectService.UpdateCrossSectionElement(simpleShape);

                return RedirectToAction("Index", "SimpleShapes");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string projectId, int simpleShapeId)
        {
            await SetProjectRelatedData(projectId);
            if (!IsReady)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View("NotFound");
            }
            var simpleShape = simpleShapesService.GetCrossSectionPart(simpleShapeId, Structure!.Id);
            if (simpleShape == null)
            {
                ViewBag.ErrorMessage = "The shape is not found or the current user doesn't have access to this shape";
                return View("NotFound");
            }

            geometryObjectService.DeleteCrossSectionElement(simpleShape);

            return RedirectToAction("Index", "SimpleShapes");
        }
    }
}
