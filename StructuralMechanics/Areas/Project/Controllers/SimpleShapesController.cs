using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Areas.Project.ViewModels;
using StructuralMechanics.Controllers;

namespace StructuralMechanics.Areas.Project.Controllers
{
    public class SimpleShapesController : BaseController
    {
        private readonly IGeometryObjectService geometryObjectService;
        private readonly IPointsService pointsService;
        private readonly ISimpleShapesService simpleShapesService;

        public SimpleShapesController(UserManager<ApplicationUser> userManager, 
                                      IProjectService projectService, 
                                      IStructureService structureService,
                                      IGeometryObjectService geometryObjectService,
                                      IPointsService pointsService,
                                      ISimpleShapesService simpleShapesService) : base(userManager, projectService, structureService)
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
            ViewBag.ProjectId = projectId;
            ViewBag.StructureType = Structure!.StructureType;

            var simpleShapes = simpleShapesService.GetSimpleShapesByStructureId(Structure!.Id);
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
            ViewBag.ProjectId = projectId;
            ViewBag.StructureType = Structure!.StructureType;

            var points = pointsService.GetPointsByStructureId(Structure!.Id);

            return View(new SimpleShapeViewModel { Points = points });
        }

        [HttpPost]
        public async Task<IActionResult> Create(string projectId, SimpleShapeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await SetProjectRelatedData(projectId);
                if (!IsReady)
                {
                    ViewBag.ErrorMessage = ErrorMessage;
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
                (bool isValid, SimpleShape? simpleShape) = SimpleShapeCreator.GetSimpleShapeObject(model);
                if (!isValid)
                {
                    ModelState.AddModelError(string.Empty, "Choose Geometry Type");
                    return View(model);
                }

                simpleShape!.StructureId = Structure!.Id;
                geometryObjectService.AddGeometryObject(simpleShape!);
                return RedirectToAction("Index", "SimpleShapes");
            }
            
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
            ViewBag.StructureType = Structure!.StructureType;

            var simpleShape = simpleShapesService.GetSimpleShape(simpleShapeId, Structure!.Id);
            if (simpleShape == null)
            {
                ViewBag.ErrorMessage = "The shape is not found or the current user doesn't have access to this shape";
                return View("NotFound");
            }

            var points = pointsService.GetPointsByStructureId(Structure!.Id);

            SimpleShapeViewModel model = new SimpleShapeViewModel()
            {
                GeometryType = simpleShape.GeometryType,
                FirstPoint = simpleShape.FirstPoint,
                SecondPoint = simpleShape.SecondPoint,
                Thickness = simpleShape.Thickness,
                FirstPointId = simpleShape.FirstPointId,
                SecondPointId = simpleShape.SecondPointId,
                Points = points
            };

            return View(model);
        }
    }
}
