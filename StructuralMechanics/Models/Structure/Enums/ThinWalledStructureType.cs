using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public enum ThinWalledStructureType
    {
        [Display(Name = "One-time closed")]
        OneTimeClosed,
        [Display(Name = "Two-time closed")]
        TwoTimeClosed
    }
}
