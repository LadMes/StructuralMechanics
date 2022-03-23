namespace StructuralMechanics.Models
{
    public interface IStructureService<T> where T : Structure
    {
        T GetStructureByProjectId(string projectId);
        T AddStructure(T structure);
        T UpdateStructure(T structure);
        T DeleteStructureById(string structureId);
    }
}
