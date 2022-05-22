namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface ICrossSectionElementRepository
    {
        List<CrossSectionElement>? GetElementsByStructureId(int structureId);
        CrossSectionElement Add(CrossSectionElement crossSectionElement);
        CrossSectionElement Update(CrossSectionElement crossSectionElement);
        CrossSectionElement Delete(CrossSectionElement crossSectionElement);
    }
}
