namespace StructuralMechanics.Models
{
    public class SQLServerStructureService : IStructureService
    {
        private readonly AppDbContext context;

        public SQLServerStructureService(AppDbContext context)
        {
            this.context = context;
        }

        public Structure AddStructure(Structure structure)
        {
            if (structure is ThinWalledStructure)
            {
                context.ThinWalledStructures.Add(structure as ThinWalledStructure);
            }
            else if (structure is CirclePlate)
            {
                context.CirclePlates.Add(structure as CirclePlate);
            }
            else if (structure is RotationalShell)
            {
                context.RotationalShells.Add(structure as RotationalShell);
            }
            else
            {
                throw new InvalidCastException();
            }
            context.SaveChanges();
            return structure;
        }

        public Structure DeleteStructureById(string structureId)
        {
            throw new NotImplementedException();
        }

        public Structure GetStructureByProjectId(string projectId)
        {
            throw new NotImplementedException();
        }

        public Structure UpdateStructure(Structure structure)
        {
            throw new NotImplementedException();
        }
    }
}
