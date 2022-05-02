namespace StructuralMechanics.Models.RepositoryPattern
{
    internal class SQLServerVectorPhysicalQuantityRepository : IVectorPhysicalQuantityRepository
    {
        private readonly AppDbContext context;

        public SQLServerVectorPhysicalQuantityRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<VectorPhysicalQuantity> GetVectorPhysicalQuantitiesByStructureId(int structureId)
        {
            return context.VectorPhysicalQuantities.Where(vpq => vpq.StructureId == structureId).ToList();
        }
    }
}
