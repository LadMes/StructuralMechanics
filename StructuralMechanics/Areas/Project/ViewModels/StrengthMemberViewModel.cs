using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class StrengthMemberViewModel : PointsViewModel
    {
        [Required]
        [Display(Name = "Reduction Coefficient")]
        public double ReductionCoefficient { get; private set; }

        [Required]
        [Display(Name = "Area")]
        public double Area { get; private set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        public Point? Location { get; set; }
    }
}
