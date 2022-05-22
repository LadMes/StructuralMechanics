namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects(string userId);
        Project? GetProjectById(string projectId);
        Project Add(Project project);
        Project Update(Project project);
        Project Delete(Project project);
    }
}
