using Microsoft.AspNetCore.Mvc.Rendering;

namespace StructuralMechanics.Models
{
    public interface IPointRepository
    {
        List<Point> GetPointsByStructureId(int structureId);
        Point? GetPoint(int pointId, int structureId);
        SelectList GetPointsForSelectListByStructureId(int structureId);
    }
}
