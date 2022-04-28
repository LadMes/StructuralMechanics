using StructuralMechanics.Utilities;
using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class SimpleShapeViewModel
    {
        public int ShapeId { get; set; }

        [Required]
        [Display(Name = "Shape Type")]
        public GeometryType? GeometryType { get; set; }

        [Required]
        [AboveZero(ErrorMessage = "Thickness cannot be 0 or less")]
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
