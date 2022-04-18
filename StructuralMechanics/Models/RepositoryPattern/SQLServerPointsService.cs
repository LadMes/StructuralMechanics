namespace StructuralMechanics.Models
{
    internal class SQLServerPointsService : IPointsService
    {
        private readonly AppDbContext context;

        public SQLServerPointsService(AppDbContext context)
        {
            this.context = context;
        }

        public Point? GetPointById(int pointId)
        {
            return context.Points.Find(pointId);
        }

        public List<Point> GetPointsByStructureId(int structureId)
        {
            return context.Points.Where(p => p.StructureId == structureId).ToList();
        }
    }
}
