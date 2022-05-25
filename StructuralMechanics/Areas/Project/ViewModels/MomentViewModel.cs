using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class MomentViewModel : BaseViewModel
    {
        [Required]
        public double Magnitude { get; set; }
        [Required]
        public Direction Direction { get; set; }
    }
}
