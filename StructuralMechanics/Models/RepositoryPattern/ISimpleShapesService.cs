namespace StructuralMechanics.Models
{
    public interface ISimpleShapesService
    {
        List<SimpleShape> GetSimpleShapesByStructureId(int structureId);
    }
}
