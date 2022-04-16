﻿using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Utilities
{
    public static class ProjectsQuery
    {
        public static IEnumerable<ProjectsViewModel> Query(ApplicationUser user, IProjectService projectService, IStructureService structureService)
        {
            var projects = projectService.GetProjects(user.Id).Select(p => new { p.Id, p.ProjectName });
            var structures = structureService.GetAllStructures().Select(s => new { s.Id, s.ProjectId, s.StructureType });

            var query = projects.Join(structures,
                                      project => project.Id,
                                      structure => structure.ProjectId,
                                      (project, structure) => new ProjectsViewModel
                                      {
                                          ProjectName = project.ProjectName,
                                          ProjectId = project.Id,
                                          StructureId = structure.Id,
                                          StructureType = structure.StructureType
                                      }).Take(10);
            return query;
        }
    }
}
