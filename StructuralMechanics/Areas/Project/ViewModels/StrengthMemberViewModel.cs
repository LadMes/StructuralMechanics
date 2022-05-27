using StructuralMechanics.Attributes;
using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class StrengthMemberViewModel : PointsViewModel, ILocation
    {
        [Required]
        [Display(Name = "Reduction Coefficient")]
        [AboveZero(ErrorMessage = "Reduction Coefficient cannot be 0 or less")]
        public double ReductionCoefficient { get; set; }

        [Required]
        [Display(Name = "Area")]
        [AboveZero(ErrorMessage = "Area cannot be 0 or less")]
        public double Area { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        public Point? Location { get; set; }
    }
}
