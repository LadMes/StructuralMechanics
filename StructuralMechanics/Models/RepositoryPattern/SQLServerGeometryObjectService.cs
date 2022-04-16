namespace StructuralMechanics.Models
{
    internal class SQLServerGeometryObjectService : IGeometryObjectService
    {
        private readonly AppDbContext context;

        public SQLServerGeometryObjectService(AppDbContext context)
        {
            this.context = context;
        }

        public GeometryObject AddGeometryObject(GeometryObject geometryObject)
        {
            context.GeometryObjects.Add(geometryObject);
            context.SaveChanges();
            return geometryObject;
        }

        public List<GeometryObject>? GetGeometryObjectsByStructureId(int structureId)
        {
            return context.GeometryObjects.Where(go => go.StructureId == structureId).ToList();
        }
    }
}
