using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.CrossSection
{
    public enum CrossSectionElementType
    {
        [Display(Name = "Point")]
        Point,
        [Display(Name = "Cross-section Part")]
        CrossSectionPart,
        [Display(Name = "Strength Member")]
        StrengthMember
    }
}
