namespace StructuralMechanics.Models
{
    public interface IStructureService
    {
        Structure GetStructureByProjectId(string projectId);
        Structure AddStructure(Structure structure);
        Structure UpdateStructure(Structure structure);
        Structure DeleteStructureById(int structureId);
    }
}
