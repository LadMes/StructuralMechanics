namespace StructuralMechanics.Models
{
    public interface IGeometryObjectService
    {
        List<GeometryObject>? GetGeometryObjectsByStructureId(int structureId);
        GeometryObject AddGeometryObject(GeometryObject geometryObject);
        GeometryObject UpdateGeometryObject(GeometryObject geometryObject);
        GeometryObject DeleteGeometryObject(GeometryObject geometryObject);
    }
}
