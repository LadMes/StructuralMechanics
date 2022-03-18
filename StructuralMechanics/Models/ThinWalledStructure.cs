using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    /// <summary>
    /// Only for symmetric on y-axis structure, you need to build only half of a geometry
    /// </summary>
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
        public double MultiplicationCoefficientForT { get; private set; }


        //Add Lists of First Moment of Area and Shear Flow, logic for properties

        public ThinWalledStructure(ThinWalledStructureType thinWalledStructureType)
        {
            this.StructureType = StructureType.ThinWalledStructure;
            this.ThinWalledStructureType = thinWalledStructureType;
        }

        public void CalculateSecondMomentOfAreaOfStructure()
        {
            this.SecondMomentOfAreaOfStructure = 0;
            
            foreach (var simpleShape in SimpleShapes)
            {
                this.SecondMomentOfAreaOfStructure += simpleShape.SecondMomentOfArea * 2;
            }

            foreach (var strengthMember in StrengthMembers)
            {
                this.SecondMomentOfAreaOfStructure += strengthMember.SecondMomentOfArea * 2;
            }
        }

        public void CalculateFullShearForce()
        {
            this.FullShearForce = 0;
            IEnumerable<VectorPhysicalQuantity> shearForceList = this.VectorPhysicalQuantities.Where(vpq => vpq.VectorType == VectorType.ShearForce);
            foreach (var shearForce in shearForceList)
            {
                this.FullShearForce += shearForce.Magnitude;
            }
        }

        public void CalculateMultiplicationCoefficientForT()
        {
            this.MultiplicationCoefficientForT = this.FullShearForce / this.SecondMomentOfAreaOfStructure;
        }
    }
}
