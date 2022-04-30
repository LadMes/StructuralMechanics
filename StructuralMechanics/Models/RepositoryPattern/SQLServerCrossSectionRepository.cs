namespace StructuralMechanics.Models
{
    internal class SQLServerCrossSectionRepository : ICrossSectionRepository
    {
        private readonly AppDbContext context;

        public SQLServerCrossSectionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CrossSection AddCrossSectionElement(CrossSection crossSectionElement)
        {
            context.CrossSectionElements.Add(crossSectionElement);
            context.SaveChanges();
            return crossSectionElement;
        }

        public CrossSection DeleteCrossSectionElement(CrossSection crossSectionElement)
        {
            context.CrossSectionElements.Remove(crossSectionElement);
            context.SaveChanges();
            return crossSectionElement;
        }

        public List<CrossSection>? GetCrossSectionElementsByStructureId(int structureId)
        {
            return context.CrossSectionElements.Where(cs => cs.StructureId == structureId).ToList();
        }

        public CrossSection UpdateCrossSectionElement(CrossSection crossSectionElement)
        {
            var crossSectionElementToUpdate = context.CrossSectionElements.Attach(crossSectionElement);
            crossSectionElementToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return crossSectionElement;
        }
    }
}
