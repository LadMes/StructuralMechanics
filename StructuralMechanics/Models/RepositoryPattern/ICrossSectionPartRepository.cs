namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface ICrossSectionPartRepository
    {
        List<CrossSectionPart> GetPartsByStructureId(int structureId);
        CrossSectionPart? Get(int crossSectionPartId, int structureId);
    }
}
