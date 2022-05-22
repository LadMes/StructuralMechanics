namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface IMomentRepository
    {
        List<Moment> GetMomentsByStructureId(int structureId);
        Moment? Get(int momentId, int structureId);
    }
}
