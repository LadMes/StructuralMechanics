namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface IVectorPhysicalQuantityRepository
    {
        List<VectorPhysicalQuantity> GetQuantitiesByStructureId(int structureId);
        VectorPhysicalQuantity Add(VectorPhysicalQuantity quantity);
        VectorPhysicalQuantity Update(VectorPhysicalQuantity quantity);
        VectorPhysicalQuantity Delete(VectorPhysicalQuantity quantity);
    }
}
