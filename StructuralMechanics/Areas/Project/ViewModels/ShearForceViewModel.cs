using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class ShearForceViewModel : PointsViewModel, ILocation
    {
        [Required]
        public double Magnitude { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }
        public Point? Location { get; set; }
    }
}
