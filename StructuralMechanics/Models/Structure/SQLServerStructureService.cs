﻿namespace StructuralMechanics.Models
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

        public Structure DeleteStructureById(string structureId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}