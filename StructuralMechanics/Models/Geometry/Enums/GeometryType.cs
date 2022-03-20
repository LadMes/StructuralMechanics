using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public enum GeometryType
    {
        Point,
        [Display(Name = "Horizontal Line")]
        HorizontalLine,
        [Display(Name = "Vertical Line")]
        VerticalLine,
        [Display(Name = "Slope Line")]
        SlopeLine,
        Arc,
        [Display(Name = "Strength Member")]
        StrengthMember
    }
}
