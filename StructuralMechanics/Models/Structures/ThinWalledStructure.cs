using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.Structures
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
            Type = StructureType.ThinWalledStructure;
            ThinWalledStructureType = thinWalledStructureType;
        }

        public void CalculateSecondMomentOfAreaOfStructure()
        {
            SecondMomentOfAreaOfStructure = 0;
            
            //To be implemented
        }

        public void CalculateFullShearForce()
        {
            FullShearForce = 0;
            IEnumerable<VectorPhysicalQuantity> shearForceList = VectorPhysicalQuantities.Where(vpq => vpq.Type == VectorType.ShearForce);
            foreach (var shearForce in shearForceList)
            {
                FullShearForce += shearForce.Magnitude;
            }
        }

        public void CalculateMultiplicationCoefficientForT()
        {
            MultiplicationCoefficientForShearFlow = FullShearForce / SecondMomentOfAreaOfStructure;
        }
    }
}
