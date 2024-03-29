﻿using Microsoft.AspNetCore.Mvc;
using StructuralMechanics.Filters;
using StructuralMechanics.Mappers;
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
        [TypeFilter(typeof(ProjectRelatedDataSetterFilter))]
        public IActionResult Index()
        {
            return View(ProjectsQuery.Query(ApplicationUser!, projectRepository, structureRepository));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(ProjectRelatedDataSetterFilter))]
        [TypeFilter(typeof(ProjectViewModelValidatorFilter))]
        public IActionResult Create(ProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.IsCreateView = true;
                return View(model);
            }

            Structure structure = StructureCreator.GetStructure(model);
            Project project = new Project()
            {
                Id = Guid.NewGuid().ToString(),
                ApplicationUser = ApplicationUser!,
                ProjectName = model.ProjectName,
                Structure = structure!
            };

            projectRepository.Add(project);
            return RedirectToAction("Overview", $"{structure!.Type}", new { projectId = $"{project.Id}", area = "Project" });
        }

        [HttpGet]
        [TypeFilter(typeof(ProjectRelatedDataSetterFilter))]
        [Route("Edit/{projectId}")]
        public IActionResult Edit()
        {
            ProjectViewModel model = ProjectMapper.Map(Project!, Structure!);

            return View(model);
        }

        [HttpPost]
        [TypeFilter(typeof(ProjectRelatedDataSetterFilter))]
        [TypeFilter(typeof(ProjectViewModelValidatorFilter))]
        [Route("Edit/{projectId}")]
        public IActionResult Edit(ProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Structure structure = StructureUpdater.GetUpdatedStructure(model, Structure!);
            Project!.ProjectName = model.ProjectName;
            structureRepository.Update(structure);
            projectRepository.Update(Project);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [TypeFilter(typeof(ProjectRelatedDataSetterFilter))]
        [Route("Delete/{projectId}")]
        public IActionResult Delete()
        {
            structureRepository.Delete(Structure!);
            projectRepository.Delete(Project!);

            return RedirectToAction("Index", "Projects");
        }
    }
}
