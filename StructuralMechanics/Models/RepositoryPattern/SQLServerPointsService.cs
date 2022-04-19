namespace StructuralMechanics.Models
{
    internal class SQLServerPointsService : IPointsService
    {
        private readonly AppDbContext context;

        public SQLServerPointsService(AppDbContext context)
        {
            this.context = context;
        }

        public Point? GetPoint(int pointId, int structureId)
        {
            var point = context.Points.Find(pointId);
            if (point == null)
                return null;
            else if (point.StructureId != structureId)
                return null;
            else 
                return point;
        }

        public List<Point> GetPointsByStructureId(int structureId)
        {
            return context.Points.Where(p => p.StructureId == structureId).ToList();
        }
    }
}
