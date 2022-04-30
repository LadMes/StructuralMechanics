namespace StructuralMechanics.Models
{
    public interface ICrossSectionRepository
    {
        List<CrossSection>? GetCrossSectionElementsByStructureId(int structureId);
        CrossSection AddCrossSectionElement(CrossSection crossSectionElement);
        CrossSection UpdateCrossSectionElement(CrossSection crossSectionElement);
        CrossSection DeleteCrossSectionElement(CrossSection crossSectionElement);
    }
}
