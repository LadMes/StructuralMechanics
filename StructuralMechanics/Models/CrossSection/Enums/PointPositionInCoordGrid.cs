using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public enum PointPositionInCoordGrid
    {
        [Display(Name = "Point is not on coord axes")]
        PointIsNotOnCoordAxes,
        [Display(Name = "Point is on X-axis")]
        PointIsOnXAxis,
        [Display(Name = "Point is on Y-axis")]
        PointIsOnYAxis,
        [Display(Name = "Starting Point")]
        StartingPoint
    }
}
