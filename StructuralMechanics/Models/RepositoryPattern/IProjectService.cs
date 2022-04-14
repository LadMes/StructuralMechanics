namespace StructuralMechanics.Models
{
    public interface IProjectService
    {
        IEnumerable<Project> GetProjects(string userId);
        Project? GetProjectById(string projectId);
        Project AddProject(Project project);
        Project UpdateProject(Project project);
        Project DeleteProject(Project project);
    }
}
