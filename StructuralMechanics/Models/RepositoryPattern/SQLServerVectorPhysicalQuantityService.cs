namespace StructuralMechanics.Models
{
    internal class SQLServerVectorPhysicalQuantityService : IVectorPhysicalQuantityService
    {
        private readonly AppDbContext context;

        public SQLServerVectorPhysicalQuantityService(AppDbContext context)
        {
            this.context = context;
        }

        public List<VectorPhysicalQuantity> GetVectorPhysicalQuantitiesByStructureId(int structureId)
        {
            return context.VectorPhysicalQuantities.Where(vpq => vpq.StructureId == structureId).ToList();
        }
    }
}
