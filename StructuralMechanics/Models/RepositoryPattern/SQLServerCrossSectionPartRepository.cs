namespace StructuralMechanics.Models.RepositoryPattern
{
    public class SQLServerCrossSectionPartRepository : ICrossSectionPartRepository
    {
        private readonly AppDbContext context;

        public SQLServerCrossSectionPartRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CrossSectionPart? Get(int crossSectionPartId, int structureId)
        {
            var crossSectionPart = context.CrossSectionParts.Find(crossSectionPartId);
            if (crossSectionPart == null || crossSectionPart.StructureId != structureId)
                return null;
            else
                return crossSectionPart;
        }

        public List<CrossSectionPart> GetPartsByStructureId(int structureId)
        {
            return context.CrossSectionParts.Where(csp => csp.StructureId == structureId).ToList();
        }
    }
}
