namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface IVectorPhysicalQuantityRepository
    {
        List<VectorPhysicalQuantity> GetVectorPhysicalQuantitiesByStructureId(int structureId);
    }
}
