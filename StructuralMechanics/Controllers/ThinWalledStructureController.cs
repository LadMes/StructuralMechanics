using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{
    [Route("Project/{projectId}/ThinWalledStructure")]
    public class ThinWalledStructureController : StructureController
    {
        public ThinWalledStructureController(UserManager<ApplicationUser> userManager,
                                             IProjectService projectService,
                                             IStructureService structureService,
                                             IGeometryObjectService geometryObjectService,
                                             IVectorPhysicalQuantityService vectorPhysicalQuantityService) 
                                            : base(userManager, projectService, structureService, 
                                                   geometryObjectService, vectorPhysicalQuantityService) { }

        // Mb there's a way to move check code somewhere, repeated code
        public override async Task<IActionResult> Overview(string projectId)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                ViewBag.ErrorMessage = "User is not found";
                return View("NotFound");
            }
            var project = projectService.GetProjectById(projectId);
            if (project == null || project.ApplicationUserId != user.Id)
            {
                ViewBag.ErrorMessage = "User does not have access to this project";
                return View("NotFound");
            }
            ViewBag.ProjectName = project.ProjectName;

            var structure = structureService.GetStructureByProjectId(projectId);
            if (structure == null)
            {
                ViewBag.ErrorMessage = "Structure is not found";
                return View("NotFound");
            }
            var geometryObjects = geometryObjectService.GetGeometryObjectsByStructureId(structure.Id);
            var vectors = vectorPhysicalQuantityService.GetVectorPhysicalQuantitiesByStructureId(structure.Id);

            //To-do: check below
            return View(GetThinWalledStructureOverviewViewModel(geometryObjects, vectors));
        }

        // To-do tommorow: this is constructor for structure type view model, so move code where it belongs and modify accordingly
        // (initially there was different idea for the method but ended up with constructor which is right way to do the thing I've imaged)
        private ThinWalledStructureOverviewViewModel GetThinWalledStructureOverviewViewModel(List<GeometryObject>? geometryObjects,
                                                              List<VectorPhysicalQuantity>? vectors)
        {
            if (geometryObjects == null && vectors == null)
            {
               return new ThinWalledStructureOverviewViewModel();
            }

            int pointsCount = geometryObjects?.Where(go => go.GeometryType == GeometryType.Point).Count() ?? 0;
            int horizontalLinesCount = geometryObjects?.Where(go => go.GeometryType == GeometryType.HorizontalLine).Count() ?? 0;
            int verticalLinesCount = geometryObjects?.Where(go => go.GeometryType == GeometryType.VerticalLine).Count() ?? 0;
            int slopeLinesCount = geometryObjects?.Where(go => go.GeometryType == GeometryType.SlopeLine).Count() ?? 0;
            int arcsCount = geometryObjects?.Where(go => go.GeometryType == GeometryType.Arc).Count() ?? 0;

            int forcesCount = vectors?.Where(v => v.VectorType == VectorType.ShearForce).Count() ?? 0;

            int strengthMembersCount = geometryObjects?.Where(go => go.GeometryType == GeometryType.StrengthMember).Count() ?? 0;
            int momentsCount = vectors?.Where(v => v.VectorType == VectorType.Moment).Count() ?? 0;

            var viewModel = new ThinWalledStructureOverviewViewModel()
            {
                GeometryObjectCount = pointsCount + horizontalLinesCount + verticalLinesCount
                                        + slopeLinesCount + arcsCount + strengthMembersCount,
                VectorPhysicalQuantitiesCount = forcesCount + momentsCount,

                PointsCount = pointsCount,
                HorizontalLinesCount = horizontalLinesCount,
                VerticalLinesCount = verticalLinesCount,
                SlopeLinesCount = slopeLinesCount,
                ArcsCount = arcsCount,
                StrengthMembersCount = strengthMembersCount,

                ForcesCount = forcesCount,
                MomentsCount = momentsCount,
            };

            return viewModel;
        }
    }
}
