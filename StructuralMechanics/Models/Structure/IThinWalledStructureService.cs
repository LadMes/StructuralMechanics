namespace StructuralMechanics.Models
{
    public interface IThinWalledStructureService
    {
        ThinWalledStructure GetThinWalledStructureByProjectId(string projectId);
        ThinWalledStructure AddThinWalledStructure(ThinWalledStructure structure);
        ThinWalledStructure UpdateThinWalledStructure(ThinWalledStructure structure);
        ThinWalledStructure DeleteThinWalledStructureById(string structureId);
    }
}
