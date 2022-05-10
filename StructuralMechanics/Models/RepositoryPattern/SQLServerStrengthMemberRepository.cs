namespace StructuralMechanics.Models.RepositoryPattern
{
    public class SQLServerStrengthMemberRepository : IStrengthMemberRepository
    {
        private readonly AppDbContext context;

        public SQLServerStrengthMemberRepository(AppDbContext context)
        {
            this.context = context;
        }

        public StrengthMember? GetStrengthMember(int strengthMemberId, int structureId)
        {
            var strengthMember = context.StrengthMembers.Find(strengthMemberId);
            if (strengthMember == null || strengthMember.StructureId != structureId)
                return null;
            else
                return strengthMember;
        }

        public List<StrengthMember> GetStrengthMembersByStructureId(int structureId)
        {
            return context.StrengthMembers.Where(sm => sm.StructureId == structureId).ToList();
        }
    }
}
