namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class ThinWalledStructureOverviewViewModel : StructureOverviewViewModel
    {
        public ThinWalledStructureOverviewViewModel(List<GeometryObject>? geometryObjects, 
                                                    List<VectorPhysicalQuantity>? vectors) : base(geometryObjects, vectors)
        {
            if (geometryObjects != null)
            {
                StrengthMembersCount = geometryObjects.Where(go => go.GeometryType == GeometryType.StrengthMember).Count();
                GeometryObjectCount += StrengthMembersCount;
            }

            if (vectors != null)
            {
                MomentsCount = vectors.Where(v => v.VectorType == VectorType.Moment).Count();
                VectorPhysicalQuantitiesCount += MomentsCount;
            } 
        }

        public int StrengthMembersCount { get; set; } = 0;
        public int MomentsCount { get; set; } = 0;
    }
}
