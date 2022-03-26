using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    /// <summary>
    /// Only for symmetric on y-axis structure, you need to build only half of a geometry
    /// </summary>
    public class ThinWalledStructure : Structure
    {  
        [Required]
        [Display(Name = "Thin-walled Structure Type")]
        public ThinWalledStructureType ThinWalledStructureType { get; set; }
        public double SecondMomentOfAreaOfStructure { get; private set; }
        public double FullShearForce { get; private set; }
        public double MultiplicationCoefficientForShearFlow { get; private set; }
        

        public ThinWalledStructure(ThinWalledStructureType thinWalledStructureType)
        {
            //this.StructureType = StructureType.ThinWalledStructure;
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
            this.MultiplicationCoefficientForShearFlow = this.FullShearForce / this.SecondMomentOfAreaOfStructure;
        }
    }
}
