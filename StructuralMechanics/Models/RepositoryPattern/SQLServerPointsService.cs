namespace StructuralMechanics.Models
{
    public class SQLServerPointsService : IPointsService
    {
        private readonly AppDbContext context;

        public SQLServerPointsService(AppDbContext context)
        {
            this.context = context;
        }

        public List<Point> GetPointsByStructureId(int structureId)
        {
            return context.Points.Where(p => p.StructureId == structureId).ToList();
        }
    }
}
