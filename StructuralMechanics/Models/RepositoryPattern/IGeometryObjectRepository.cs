namespace StructuralMechanics.Models
{
    public interface IGeometryObjectRepository
    {
        List<GeometryObject>? GetGeometryObjectsByStructureId(int structureId);
        GeometryObject AddGeometryObject(GeometryObject geometryObject);
        GeometryObject UpdateGeometryObject(GeometryObject geometryObject);
        GeometryObject DeleteGeometryObject(GeometryObject geometryObject);
    }
}
