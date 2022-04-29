namespace StructuralMechanics.Models
{
    public interface ISimpleShapesRepository
    {
        List<SimpleShape> GetSimpleShapesByStructureId(int structureId);
        SimpleShape? GetSimpleShape(int simpleShapeId, int structureId);
    }
}
