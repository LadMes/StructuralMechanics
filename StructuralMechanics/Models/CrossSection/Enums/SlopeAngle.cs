using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.CrossSection
{
    public enum SlopeAngle
    {
        [Display(Name = "Acute Angle")]
        AcuteAngle,
        [Display(Name = "Obtuse Angle")]
        ObtuseAngle
    }
}
