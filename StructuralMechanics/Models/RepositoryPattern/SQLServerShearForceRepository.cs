namespace StructuralMechanics.Models.RepositoryPattern
{
    public class SQLServerShearForceRepository : IShearForceRepository
    {
        private readonly AppDbContext context;

        public SQLServerShearForceRepository(AppDbContext context)
        {
            this.context = context;
        }

        public ShearForce? Get(int shearForceId, int structureId)
        {
            var force = context.ShearForces.Find(shearForceId);
            if (force == null || force.StructureId != structureId)
                return null;
            else
                return force;
        }

        public List<ShearForce> GetForcesByStructureId(int structureId)
        {
            return context.ShearForces.Where(shearForce => shearForce.StructureId == structureId).ToList();
        }
    }
}
