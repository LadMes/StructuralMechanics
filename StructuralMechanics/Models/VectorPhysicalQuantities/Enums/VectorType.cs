using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.VectorPhysicalQuantities
{
    public enum VectorType
    {
        [Display(Name = "Shear Force")]
        ShearForce,
        Moment
    }
}
