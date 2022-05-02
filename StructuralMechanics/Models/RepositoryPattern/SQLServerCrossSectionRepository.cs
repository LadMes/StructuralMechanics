namespace StructuralMechanics.Models.RepositoryPattern
{
    internal class SQLServerCrossSectionRepository : ICrossSectionElementRepository
    {
        private readonly AppDbContext context;

        public SQLServerCrossSectionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CrossSectionElement AddCrossSectionElement(CrossSectionElement crossSectionElement)
        {
            context.CrossSectionElements.Add(crossSectionElement);
            context.SaveChanges();
            return crossSectionElement;
        }

        public CrossSectionElement DeleteCrossSectionElement(CrossSectionElement crossSectionElement)
        {
            context.CrossSectionElements.Remove(crossSectionElement);
            context.SaveChanges();
            return crossSectionElement;
        }

        public List<CrossSectionElement>? GetCrossSectionElementsByStructureId(int structureId)
        {
            return context.CrossSectionElements.Where(cse => cse.StructureId == structureId).ToList();
        }

        public CrossSectionElement UpdateCrossSectionElement(CrossSectionElement crossSectionElement)
        {
            var crossSectionElementToUpdate = context.CrossSectionElements.Attach(crossSectionElement);
            crossSectionElementToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return crossSectionElement;
        }
    }
}
