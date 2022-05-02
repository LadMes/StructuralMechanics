using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.Structures
{
    public enum StructureType
    {
        [Display(Name = "Thin-walled Structure")]
        ThinWalledStructure,
        [Display(Name = "Circle Plate")]
        CirclePlate,
        [Display(Name = "Rotational Shell")]
        RotationalShell
    }
}
