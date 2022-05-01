using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public enum CrossSectionPartType
    {
        [Display(Name = "Horizontal Line")]
        HorizontalLine,
        [Display(Name = "Vertical Line")]
        VerticalLine,
        [Display(Name = "Slope Line")]
        SlopeLine,
        [Display(Name = "Arc")]
        Arc
    }
}
