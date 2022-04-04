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

        public Structure DeleteStructureById(int structureId)
        {
            var structure = context.Structures.Find(structureId);
            if (structure != null)
            {
                context.Structures.Remove(structure);
                context.SaveChanges();
            }
            return structure;
        }

        public IEnumerable<Structure> GetAllStructures()
        {
            return context.Structures;
        }

        public Structure GetStructureByProjectId(string projectId)
        {
            var structure = context.Structures.Single(s => s.ProjectId == projectId);
            if (structure != null)
            {
                return structure;
            }

            return null;
        }

        public Structure GetStructureByStructureId(int structureId)
        {
            return context.Structures.Find(structureId);
        }

        public Structure UpdateStructure(Structure structure)
        {
            if (structure is ThinWalledStructure thinWalledStructure)
            {
                var thinWalledStructureToUpdate = context.ThinWalledStructures.Attach(thinWalledStructure);
                thinWalledStructureToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else if (structure is CirclePlate circlePlate)
            {
                var circlePlateToUpdate = context.CirclePlates.Attach(circlePlate);
                circlePlateToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else if (structure is RotationalShell rotationalShell)
            {
                var rotationalShellToUpdate =  context.RotationalShells.Attach(rotationalShell);
                rotationalShellToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                throw new InvalidCastException();
            }

            context.SaveChanges();
            return structure;
        }
    }
}
