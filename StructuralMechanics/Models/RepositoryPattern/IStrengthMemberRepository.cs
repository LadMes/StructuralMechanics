namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface IStrengthMemberRepository
    {
        List<StrengthMember> GetStrengthMembersByStructureId(int structureId);
        StrengthMember? Get(int strengthMemberId, int structureId);
    }
}
