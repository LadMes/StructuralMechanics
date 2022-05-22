namespace StructuralMechanics.Models.RepositoryPattern
{
    public class SQLServerMomentRepository : IMomentRepository
    {
        private readonly AppDbContext context;

        public SQLServerMomentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Moment? Get(int momentId, int structureId)
        {
            var moment = context.Moments.Find(momentId);
            if (moment == null || moment.StructureId != structureId)
                return null;
            return moment;
        }

        public List<Moment> GetMomentsByStructureId(int structureId)
        {
            return context.Moments.Where(m => m.StructureId == structureId).ToList();
        }
    }
}
