using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.ViewModels
{
    public class CreatePointViewModel
    {
        [Required]
        [Display(Name = "Coord. X:")]
        public double X { get; set; }

        [Required]
        [Display(Name = "Coord. Y:")]
        public double Y { get; set; }
    }
}
