namespace StructuralMechanics.Models
{
    public interface IVectorPhysicalQuantityService
    {
        List<VectorPhysicalQuantity> GetVectorPhysicalQuantitiesByStructureId(int structureId);
    }
}
