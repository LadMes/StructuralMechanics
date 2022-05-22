namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface IStructureRepository
    {
        IEnumerable<Structure> GetAllStructures();
        Structure? GetStructureByStructureId(int structureId);
        Structure? GetStructureByProjectId(string projectId);
        Structure Add(Structure structure);
        Structure Update(Structure structure);
        Structure Delete(Structure structure);
    }
}
