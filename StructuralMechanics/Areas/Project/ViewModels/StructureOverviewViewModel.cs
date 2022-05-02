namespace StructuralMechanics.Areas.Project.ViewModels
{
    public abstract class StructureOverviewViewModel
    {
        public StructureOverviewViewModel(List<CrossSectionElement>? crossSectionElements, List<VectorPhysicalQuantity>? vectors)
        {
            if (crossSectionElements != null)
            {
                var crossSectionPart = crossSectionElements.Where(cse => cse.ElementType == CrossSectionElementType.CrossSectionPart)
                                                           .Cast<CrossSectionPart>();
                PointsCount = crossSectionElements.Where(cse => cse.ElementType == CrossSectionElementType.Point).Count();
                HorizontalLinesCount = crossSectionPart.Where(csp => csp.Type == CrossSectionPartType.HorizontalLine).Count();
                VerticalLinesCount = crossSectionPart.Where(csp => csp.Type == CrossSectionPartType.VerticalLine).Count();
                SlopeLinesCount = crossSectionPart.Where(csp => csp.Type == CrossSectionPartType.SlopeLine).Count();
                ArcsCount = crossSectionPart.Where(csp => csp.Type == CrossSectionPartType.Arc).Count();

                CrossSectionElementsCount = PointsCount + HorizontalLinesCount + VerticalLinesCount + ArcsCount;
            }
            if (vectors != null)
            {
                ForcesCount = vectors.Where(v => v.Type == VectorType.ShearForce).Count();
                VectorPhysicalQuantitiesCount = ForcesCount;
            }       
        }

        public int CrossSectionElementsCount { get; set; } = 0;
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
