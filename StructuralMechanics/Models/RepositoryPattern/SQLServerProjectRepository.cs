namespace StructuralMechanics.Models.RepositoryPattern
{
    internal class SQLServerProjectRepository : IProjectRepository
    {
        private readonly AppDbContext context;

        public SQLServerProjectRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Project AddProject(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
            return project;
        }

        public Project DeleteProject(Project project)
        {
            context.Projects.Remove(project);
            context.SaveChanges(); 
            return project;
        }

        public Project? GetProjectById(string projectId)
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
