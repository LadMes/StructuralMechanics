namespace StructuralMechanics.Models
{
    public interface IPointsService
    {
        List<Point> GetPointsByStructureId(int structureId);
        Point? GetPointById(int pointId);
    }
}
