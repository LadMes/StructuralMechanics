namespace StructuralMechanics.ViewModels
{
    public class StructureOverviewViewModel
    {
        public int GeometryObjectCount { get; set; }
        public int VectorPhysicalQuantitiesCount { get; set; }

        public int PointsCount { get; set; }
        public int SimpleShapesCount { get; set; }

        //For future
        //public int Constraints { get; set; }
    }
}
