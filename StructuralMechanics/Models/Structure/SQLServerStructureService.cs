namespace StructuralMechanics.Models
{
    public class SQLServerStructureService<T> : IStructureService<T> where T : Structure
    {
        private readonly AppDbContext context;

        public SQLServerStructureService(AppDbContext context)
        {
            this.context = context;
        }

        public T AddStructure(T structure)
        {
            if (structure is ThinWalledStructure thinWalledStructure)
            {
                context.ThinWalledStructures.Add(thinWalledStructure);
            }
            else if (structure is CirclePlate circlePlate)
            {
                context.CirclePlates.Add(circlePlate);
            }
            else if (structure is RotationalShell rotationalShell)
            {
                context.RotationalShells.Add(rotationalShell);
            }
            else
            {
                throw new InvalidCastException();
            }
            context.SaveChanges();
            return structure;
        }

        public T DeleteStructureById(string structureId)
        {
            throw new NotImplementedException();
        }

        public T GetStructureByProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public T UpdateStructure(T structure)
        {
            throw new NotImplementedException();
        }
    }
}
