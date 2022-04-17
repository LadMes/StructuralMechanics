using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class PointViewModel
    {
        [Required]
        [Display(Name = "Coord. X:")]
        public double X { get; set; }

        [Required]
        [Display(Name = "Coord. Y:")]
        public double Y { get; set; }
    }
}
