namespace StructuralMechanics.Models
{
    public interface IPointsService
    {
        List<Point> GetPointsByStructureId(int structureId);
        Point? GetPoint(int pointId, int structureId);
    }
}
