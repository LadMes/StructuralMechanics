namespace StructuralMechanics.ViewModels
{
    public abstract class StructureOverviewViewModel
    {
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
