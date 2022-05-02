namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface ICrossSectionPartRepository
    {
        List<CrossSectionPart> GetCrossSectionPartsByStructureId(int structureId);
        CrossSectionPart? GetCrossSectionPart(int crossSectionPartId, int structureId);
    }
}
