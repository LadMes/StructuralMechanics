using StructuralMechanics.Utilities;
using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class SimpleShapeViewModel
    {
        [Required]
        [Display(Name = "Shape Type")]
        public GeometryType? GeometryType { get; set; }
        [Required]
        [NotBelowZero(ErrorMessage = "Thickness must be positive")]
        public double Thickness { get; set; }
        [Required]
        [Display(Name = "First Point")]
        public int FirstPointId { get; set; }
        [Required]
        [Display(Name = "Second Point")]
        public int SecondPointId { get; set; }


        public List<Point> Points { get; set; } = new List<Point>();
        public Point? FirstPoint { get; set; } = null;
        public Point? SecondPoint { get; set; } = null;
    }
}
