namespace StructuralMechanics.Models.RepositoryPattern
{
    internal class SQLServerVectorPhysicalQuantityRepository : IVectorPhysicalQuantityRepository
    {
        private readonly AppDbContext context;

        public SQLServerVectorPhysicalQuantityRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<VectorPhysicalQuantity> GetQuantitiesByStructureId(int structureId)
        {
            return context.VectorPhysicalQuantities.Where(vpq => vpq.StructureId == structureId).ToList();
        }

        public VectorPhysicalQuantity Add(VectorPhysicalQuantity quantity)
        {
            context.VectorPhysicalQuantities.Add(quantity);
            context.SaveChanges();
            return quantity;
        }

        public VectorPhysicalQuantity Update(VectorPhysicalQuantity quantity)
        {
            var entity = context.VectorPhysicalQuantities.Attach(quantity);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return quantity;
        }

        public VectorPhysicalQuantity Delete(VectorPhysicalQuantity quantity)
        {
            context.VectorPhysicalQuantities.Remove(quantity);
            context.SaveChanges();
            return quantity;
        }
    }
}
