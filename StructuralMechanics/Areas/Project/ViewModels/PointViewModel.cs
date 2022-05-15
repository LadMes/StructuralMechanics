using StructuralMechanics.Attributes;
using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class PointViewModel : CrossSectionElementViewModel
    {
        [Required]
        [Display(Name = "Coord. X:")]
        [NotBelowZero(ErrorMessage = "Coordinate must be positive")]
        public double X { get; set; }

        [Required]
        [Display(Name = "Coord. Y:")]
        [NotBelowZero(ErrorMessage = "Coordinate must be positive")]
        public double Y { get; set; }
    }
}
