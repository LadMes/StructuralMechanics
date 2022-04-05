namespace StructuralMechanics.Models
{
    public class SQLServerGeometryObjectService : IGeometryObjectService
    {
        private readonly AppDbContext context;

        public SQLServerGeometryObjectService(AppDbContext context)
        {
            this.context = context;
        }

        public List<GeometryObject>? GetGeometryObjectsByStructureId(int structureId)
        {
            return context.GeometryObjects.Where(go => go.StructureId == structureId).ToList();
        }
    }
}
