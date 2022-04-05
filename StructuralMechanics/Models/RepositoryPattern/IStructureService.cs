﻿namespace StructuralMechanics.Models
{
    public interface IStructureService
    {
        IEnumerable<Structure> GetAllStructures();
        Structure GetStructureByStructureId(int structureId);
        Structure GetStructureByProjectId(string projectId);
        Structure AddStructure(Structure structure);
        Structure UpdateStructure(Structure structure);
        Structure DeleteStructureById(int structureId);
    }
}