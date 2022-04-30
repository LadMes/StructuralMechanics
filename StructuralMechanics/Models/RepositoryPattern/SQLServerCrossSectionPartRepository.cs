namespace StructuralMechanics.Models
{
    public class SQLServerCrossSectionPartRepository : ICrossSectionPartRepository
    {
        private readonly AppDbContext context;

        public SQLServerCrossSectionPartRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CrossSectionPart? GetCrossSectionPart(int crossSectionPartId, int structureId)
        {
            var crossSectionPart = context.CrossSectionParts.Find(crossSectionPartId);
            if (crossSectionPart == null || crossSectionPart.StructureId != structureId)
                return null;
            else
                return crossSectionPart;
        }

        public List<CrossSectionPart> GetCrossSectionPartsByStructureId(int structureId)
        {
            return context.CrossSectionParts.Where(csp => csp.StructureId == structureId).ToList();
        }
    }
}
