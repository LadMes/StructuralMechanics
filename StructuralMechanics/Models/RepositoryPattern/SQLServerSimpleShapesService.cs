namespace StructuralMechanics.Models
{
    public class SQLServerSimpleShapesService : ISimpleShapesService
    {
        private readonly AppDbContext context;

        public SQLServerSimpleShapesService(AppDbContext context)
        {
            this.context = context;
        }

        public SimpleShape? GetSimpleShape(int simpleShapeId, int structureId)
        {
            var simpleShape = context.SimpleShapes.Find(simpleShapeId);
            if (simpleShape == null || simpleShape.StructureId != structureId)
                return null;
            else
                return simpleShape;
        }

        public List<SimpleShape> GetSimpleShapesByStructureId(int structureId)
        {
            return context.SimpleShapes.Where(ss => ss.StructureId == structureId).ToList();
        }
    }
}
