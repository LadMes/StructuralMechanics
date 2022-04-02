namespace StructuralMechanics.Models
{
    public interface IStructureService
    {
        IEnumerable<Structure> GetAllStructures();
        Structure GetStructureByProjectId(string projectId);
        Structure AddStructure(Structure structure);
        Structure UpdateStructure(Structure structure);

        // This method is not required due to the cascade delete mode.
        //Structure DeleteStructureById(int structureId);
    }
}
