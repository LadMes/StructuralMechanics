namespace StructuralMechanics.Models.RepositoryPattern
{
    public interface IStrengthMemberRepository
    {
        List<StrengthMember> GetStrengthMembersByStructureId(int structureId);
        StrengthMember? GetStrengthMember(int strengthMemberId, int structureId);
    }
}
