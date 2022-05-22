namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface IShearForceRepository
    {
        List<ShearForce> GetForcesByStructureId(int structureId);
        ShearForce? Get(int shearForceId, int structureId);
    }
}
