namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class ThinWalledStructureOverviewViewModel : StructureOverviewViewModel
    {
        public ThinWalledStructureOverviewViewModel(List<CrossSectionElement>? crossSectionElements, 
                                                    List<VectorPhysicalQuantity>? vectors) : base(crossSectionElements, vectors)
        {
            if (crossSectionElements != null)
            {
                StrengthMembersCount = crossSectionElements.Where(cse => cse.ElementType == CrossSectionElementType.StrengthMember).Count();
                CrossSectionElementsCount += StrengthMembersCount;
            }

            if (vectors != null)
            {
                MomentsCount = vectors.Where(v => v.Type == VectorType.Moment).Count();
                VectorPhysicalQuantitiesCount += MomentsCount;
            } 
        }

        public int StrengthMembersCount { get; set; } = 0;
        public int MomentsCount { get; set; } = 0;
    }
}
