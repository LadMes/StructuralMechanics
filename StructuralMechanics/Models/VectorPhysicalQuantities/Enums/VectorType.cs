using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public enum VectorType
    {
        [Display(Name = "Shear Force")]
        ShearForce,
        Moment
    }
}
