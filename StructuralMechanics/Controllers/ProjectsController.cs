using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Filters;
using StructuralMechanics.Utilities;
using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Controllers
{
    public class ProjectsController : BaseInformationController
    {
        public ProjectsController(IProjectRepository projectRepository, 
                                  IStructureRepository structureRepository) : base(projectRepository, structureRepository)
        {
        }

        [HttpGet]
        [TypeFilter(typeof(SetProjectRelatedDataFilter))]
        public IActionResult Index()
        {
            if (ApplicationUser == null)
            {
                return View("NotFound");
            }

            return View(ProjectsQuery.Query(ApplicationUser, projectRepository, structureRepository));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(SetProjectRelatedDataFilter))]
        public IActionResult Create(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (ApplicationUser == null)
                {
                    return View("NotFound");
                }

                (bool isStructureValid, string errorMessage, Structure? structure) = StructureCreator.GetStructure(model);

                if (!isStructureValid)
                {
                    model.StructureType = null;
                    ModelState.AddModelError(string.Empty, errorMessage);
                    return View(model);
                }

                Project project = new Project()
                {
                    Id = Guid.NewGuid().ToString(),
                    ApplicationUser = ApplicationUser,
                    ProjectName = model.ProjectName,
                    Structure = structure!
                };

                projectRepository.AddProject(project);
                return RedirectToAction("Overview", $"{structure!.Type}", new { projectId = $"{project.Id}", area = "Project" });
            }

            model.StructureType = null;
            return View(model);
        }

        [HttpGet]
        [TypeFilter(typeof(SetProjectRelatedDataFilter))]
        [Route("Edit/{projectId}")]
        public IActionResult Edit()
        {
            if (!IsReady)
            {
                return View("NotFound");
            }

            ProjectViewModel model = new ProjectViewModel()
            {
                ProjectName = Project!.ProjectName,
                StructureType = Structure!.Type,
                ThinWalledStructureType = (Structure.Type == StructureType.ThinWalledStructure) 
                                            ? ((ThinWalledStructure)Structure).ThinWalledStructureType 
                                            : null
            };

            return View(model);
        }

        [HttpPost]
        [TypeFilter(typeof(SetProjectRelatedDataFilter))]
        [Route("Edit/{projectId}")]
        public IActionResult Edit(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!IsReady)
                {
                    return View("NotFound");
                }

                (bool isStructureValid, string errorMessage, Structure structure) = StructureUpdater.GetUpdatedStructure(model, Structure!);
                if (!isStructureValid)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                    return View(model);
                }

                Project!.ProjectName = model.ProjectName;
                // If we don't update structure info there's no need for calling update structure
                structureRepository.UpdateStructure(structure);
                projectRepository.UpdateProject(Project);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [TypeFilter(typeof(SetProjectRelatedDataFilter))]
        [Route("Delete/{projectId}")]
        public IActionResult Delete()
        {
            if (!IsReady)
            {
                return View("NotFound");
            }

            structureRepository.DeleteStructure(Structure!);
            projectRepository.DeleteProject(Project!);

            return RedirectToAction("Index", "Projects");
        }
    }
}
