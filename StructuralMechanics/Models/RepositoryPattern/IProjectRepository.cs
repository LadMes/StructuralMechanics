namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects(string userId);
        Project? GetProjectById(string projectId);
        Project AddProject(Project project);
        Project UpdateProject(Project project);
        Project DeleteProject(Project project);
    }
}
