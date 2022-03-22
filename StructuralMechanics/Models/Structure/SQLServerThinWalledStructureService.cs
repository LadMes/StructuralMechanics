namespace StructuralMechanics.Models
{
    public class SQLServerThinWalledStructureService : IThinWalledStructureService
    {
        private readonly AppDbContext context;

        public SQLServerThinWalledStructureService(AppDbContext context)
        {
            this.context = context;
        }

        public ThinWalledStructure AddThinWalledStructure(ThinWalledStructure structure)
        {
            context.ThinWalledStructures.Add(structure);
            context.SaveChanges();
            return structure;
        }

        public ThinWalledStructure DeleteThinWalledStructureById(string structureId)
        {
            throw new NotImplementedException();
        }

        public ThinWalledStructure GetThinWalledStructureByProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public ThinWalledStructure UpdateThinWalledStructure(ThinWalledStructure structure)
        {
            throw new NotImplementedException();
        }
    }
}
