namespace StructuralMechanics.Models
{
    public interface IVectorPhysicalQuantityRepository
    {
        List<VectorPhysicalQuantity> GetVectorPhysicalQuantitiesByStructureId(int structureId);
    }
}
