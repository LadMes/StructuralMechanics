namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface IStructureRepository
    {
        IEnumerable<Structure> GetAllStructures();
        Structure? GetStructureByStructureId(int structureId);
        Structure? GetStructureByProjectId(string projectId);
        Structure AddStructure(Structure structure);
        Structure UpdateStructure(Structure structure);
        Structure DeleteStructure(Structure structure);
    }
}
