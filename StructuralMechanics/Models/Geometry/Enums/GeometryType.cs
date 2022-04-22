using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public enum GeometryType
    {
        [Display(Name = "Point")]
        Point,
        [Display(Name = "Horizontal Line")]
        HorizontalLine,
        [Display(Name = "Vertical Line")]
        VerticalLine,
        [Display(Name = "Slope Line")]
        SlopeLine,
        [Display(Name = "Arc")]
        Arc,
        [Display(Name = "Strength Member")]
        StrengthMember
    }
}
