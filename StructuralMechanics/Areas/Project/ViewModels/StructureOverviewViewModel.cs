namespace StructuralMechanics.Areas.Project.ViewModels
{
    public abstract class StructureOverviewViewModel
    {
        public StructureOverviewViewModel(List<CrossSection>? geometryObjects, List<VectorPhysicalQuantity>? vectors)
        {
            if (geometryObjects != null)
            {
                PointsCount = geometryObjects.Where(go => go.GeometryType == CrossSectionPartType.Point).Count();
                HorizontalLinesCount = geometryObjects.Where(go => go.GeometryType == CrossSectionPartType.HorizontalLine).Count();
                VerticalLinesCount = geometryObjects.Where(go => go.GeometryType == CrossSectionPartType.VerticalLine).Count();
                SlopeLinesCount = geometryObjects.Where(go => go.GeometryType == CrossSectionPartType.SlopeLine).Count();
                ArcsCount = geometryObjects.Where(go => go.GeometryType == CrossSectionPartType.Arc).Count();

                GeometryObjectCount = PointsCount + HorizontalLinesCount + VerticalLinesCount + ArcsCount;
            }
            if (vectors != null)
            {
                ForcesCount = vectors.Where(v => v.Type == VectorType.ShearForce).Count();
                VectorPhysicalQuantitiesCount = ForcesCount;
            }       
        }

        public int GeometryObjectCount { get; set; } = 0;
        public int VectorPhysicalQuantitiesCount { get; set; } = 0;

        public int PointsCount { get; set; } = 0;
        public int HorizontalLinesCount { get; set; } = 0;
        public int VerticalLinesCount { get; set; } = 0;
        public int SlopeLinesCount { get; set; } = 0;
        public int ArcsCount { get; set; } = 0;

        public int ForcesCount { get; set; } = 0;

        //For future
        //public int Constraints { get; set; }
    }
}
