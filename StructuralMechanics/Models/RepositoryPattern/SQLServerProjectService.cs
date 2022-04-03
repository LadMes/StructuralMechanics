using StructuralMechanics.ViewModels;

namespace StructuralMechanics.Models
{
    public class SQLServerProjectService : IProjectService
    {
        private readonly AppDbContext context;

        public SQLServerProjectService(AppDbContext context)
        {
            this.context = context;
        }

        public Project AddProject(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
            return project;
        }

        public Project DeleteProjectById(string projectId)
        {
            Project project = context.Projects.Find(projectId);

            if (project != null)
            {
                //var structure = structureService.GetStructureByProjectId(projectId);
                //structureService.DeleteStructureById(structure.Id);
                context.Projects.Remove(project);
                context.SaveChanges();
            }
            
            return project;
        }

        public Project GetProjectById(string projectId)
        {
            return context.Projects.Find(projectId);
        }

        public IEnumerable<Project> GetProjects(string userId)
        {
            return context.Projects.Where(p => p.ApplicationUser.Id == userId);
        }

        public Project UpdateProject(Project project)
        {
            var projectToUpdate = context.Projects.Attach(project);

            projectToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();

            return project;
        }
    }
}
