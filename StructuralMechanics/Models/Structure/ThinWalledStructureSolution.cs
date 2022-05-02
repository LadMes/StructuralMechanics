namespace StructuralMechanics.Models
{
    public class ThinWalledStructureSolution
    {
        public List<double> SheathStresses { get; private set; }
        public double MaxSheathStress { get; private set; }
        public List<double> StrengthMemberStresses { get; private set; }
        public double MaxStrengthMemberStress { get; private set; }
    }
}
