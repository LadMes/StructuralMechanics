using Microsoft.AspNetCore.Mvc.Rendering;

namespace StructuralMechanics.Models
{
    internal class SQLServerPointsRepository : IPointsRepository
    {
        private readonly AppDbContext context;

        public SQLServerPointsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Point? GetPoint(int pointId, int structureId)
        {
            var point = context.Points.Find(pointId);
            if (point == null || point.StructureId != structureId)
                return null;
            else 
                return point;
        }

        public List<Point> GetPointsByStructureId(int structureId)
        {
            return context.Points.Where(p => p.StructureId == structureId).ToList();
        }

        public SelectList GetPointsForSelectListByStructureId(int structureId)
        {
            var points = GetPointsByStructureId(structureId);
            return new SelectList(points.Select(p => new SelectListItem(p.ToString(), p.Id.ToString())).ToList(), "Value", "Text");
        }
    }
}
