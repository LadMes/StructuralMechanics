namespace StructuralMechanics.Models
{
    public class SQLServerStructureService : IStructureService
    {
        private readonly AppDbContext context;
        private readonly IProjectService projectService;

        public SQLServerStructureService(AppDbContext context, IProjectService projectService)
        {
            this.context = context;
            this.projectService = projectService;
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
                //var project = context.Projects.Find(structure.Project.Id);
                context.Structures.Remove(structure);
                //projectService.DeleteProjectById(project.Id);
                context.SaveChanges();
            } 
            return structure;
        }

        public Structure GetStructureByProjectId(string projectId)
        {
            var project = projectService.GetProjectById(projectId);
            if (project.StructureType == StructureType.ThinWalledStructure)
            {
                return context.ThinWalledStructures.Find(project.StructureId);
            }
            else if (project.StructureType == StructureType.CirclePlate)
            {
                return context.CirclePlates.Find(project.StructureId);
            }
            else if (project.StructureType == StructureType.RotationalShell)
            {
                return context.RotationalShells.Find(project.StructureId);
            }

            return null;
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
