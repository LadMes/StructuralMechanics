using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.VectorPhysicalQuantities
{
    public enum Direction
    {
        [Display(Name = "Along Y-Axis")]
        AlongYAxis,
        [Display(Name = "Opposite Y-Axis")]
        OppositeYAxis,
        Clockwise,
        [Display(Name = "Counter Clockwise")]
        Counterclockwise
    }
}
