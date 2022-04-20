namespace StructuralMechanics.Models
{
    public class SQLServerSimpleShapesService : ISimpleShapesService
    {
        private readonly AppDbContext context;

        public SQLServerSimpleShapesService(AppDbContext context)
        {
            this.context = context;
        }

        public List<SimpleShape> GetSimpleShapesByStructureId(int structureId)
        {
            return context.SimpleShapes.Where(ss => ss.StructureId == structureId).ToList();
        }
    }
}
