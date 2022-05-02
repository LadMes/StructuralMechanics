﻿namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface ICrossSectionElementRepository
    {
        List<CrossSectionElement>? GetCrossSectionElementsByStructureId(int structureId);
        CrossSectionElement AddCrossSectionElement(CrossSectionElement crossSectionElement);
        CrossSectionElement UpdateCrossSectionElement(CrossSectionElement crossSectionElement);
        CrossSectionElement DeleteCrossSectionElement(CrossSectionElement crossSectionElement);
    }
}
