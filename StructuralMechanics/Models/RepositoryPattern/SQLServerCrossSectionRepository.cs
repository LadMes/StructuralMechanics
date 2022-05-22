namespace StructuralMechanics.Models.RepositoryPattern
{
    internal class SQLServerCrossSectionRepository : ICrossSectionElementRepository
    {
        private readonly AppDbContext context;

        public SQLServerCrossSectionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CrossSectionElement Add(CrossSectionElement crossSectionElement)
        {
            context.CrossSectionElements.Add(crossSectionElement);
            context.SaveChanges();
            return crossSectionElement;
        }

        public CrossSectionElement Delete(CrossSectionElement crossSectionElement)
        {
            context.CrossSectionElements.Remove(crossSectionElement);
            context.SaveChanges();
            return crossSectionElement;
        }

        public List<CrossSectionElement>? GetElementsByStructureId(int structureId)
        {
            return context.CrossSectionElements.Where(cse => cse.StructureId == structureId).ToList();
        }

        public CrossSectionElement Update(CrossSectionElement crossSectionElement)
        {
            var entity = context.CrossSectionElements.Attach(crossSectionElement);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return crossSectionElement;
        }
    }
}
