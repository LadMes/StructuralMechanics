using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public class ThinWalledStructure : Structure
    {
        [Required]
        public ThinWalledStructureType ThinWalledStructureType { get; set; }
        public double SecondMomentOfAreaOfStructure { get; private set; }
        public List<double> SheathStresses { get; private set; }
        public double MaxSheathStress { get; private set; }
        public List<double> StrengthMemberStresses { get; private set; }
        public double MaxStrengthMemberStress { get; private set; }
        public double FullShearForce { get; private set; }

        //Add Lists of First Moment of Area and Shear Force by thickness, logic for properties

        public ThinWalledStructure(ThinWalledStructureType thinWalledStructureType)
        {
            this.StructureType = StructureType.ThinWalledStructure;
            this.ThinWalledStructureType = thinWalledStructureType;
        }

        public void CalculateSecondMomentOfAreaOfStructure()
        {
            //Write logic here
            return;
        }

        public void CalculateFullShearForce()
        {
            //Write logic here
            return;
        }
    }
}
