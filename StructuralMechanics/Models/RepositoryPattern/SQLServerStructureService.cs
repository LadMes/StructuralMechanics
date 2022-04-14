﻿namespace StructuralMechanics.Models
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
            context.Structures.Add(structure);
            context.SaveChanges();
            return structure;
        }

        public Structure DeleteStructure(Structure structure)
        {
            context.Structures.Remove(structure);
            context.SaveChanges();
            return structure;
        }

        public IEnumerable<Structure> GetAllStructures()
        {
            return context.Structures;
        }

        public Structure? GetStructureByProjectId(string projectId)
        {
            var structure = context.Structures.Single(s => s.ProjectId == projectId);       
            return structure;
        }

        public Structure? GetStructureByStructureId(int structureId)
        {
            return context.Structures.Find(structureId);
        }

        public Structure UpdateStructure(Structure structure)
        {
            var structureToUpdate = context.Structures.Attach(structure);
            structureToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return structure;
        }
    }
}
