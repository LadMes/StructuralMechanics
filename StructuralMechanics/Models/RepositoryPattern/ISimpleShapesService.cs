namespace StructuralMechanics.Models
{
    public interface ISimpleShapesService
    {
        List<SimpleShape> GetSimpleShapesByStructureId(int structureId);
        SimpleShape? GetSimpleShape(int simpleShapeId, int structureId);
    }
}
