using StructuralMechanics.Utilities;
using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class SimpleShapeViewModel
    {
        [Required]
        [Display(Name = "Shape Type")]
        public GeometryType GeometryType { get; set; }
        [Required]
        [NotBelowZero(ErrorMessage = "Thickness must be positive")]
        public double Thickness { get; set; }
        [Required]
        [Display(Name = "First Point")]
        public Point? FirstPoint { get; set; } = null;
        [Required]
        [Display(Name = "Second Point")]
        public Point? SecondPoint { get; set; } = null;

        public List<Point> Points { get; set; } = new List<Point>();
    }
}
