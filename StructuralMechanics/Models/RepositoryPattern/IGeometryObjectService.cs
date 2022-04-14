namespace StructuralMechanics.Models
{
    public interface IGeometryObjectService
    {
        List<GeometryObject>? GetGeometryObjectsByStructureId(int structureId);
        GeometryObject AddGeometryObject(GeometryObject geometryObject);
    }
}
