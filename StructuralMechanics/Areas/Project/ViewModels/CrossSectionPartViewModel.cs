using Microsoft.AspNetCore.Mvc.Rendering;
using StructuralMechanics.Attributes;
using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class CrossSectionPartViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cross-Section Part Type")]
        public CrossSectionPartType? Type { get; set; }

        [Required]
        [AboveZero(ErrorMessage = "Thickness cannot be 0 or less")]
        public double Thickness { get; set; }

        [Required]
        [Display(Name = "First Point")]
        public int FirstPointId { get; set; }

        [Required]
        [Display(Name = "Second Point")]
        public int SecondPointId { get; set; }


        public SelectList? Points { get; set; }
        public Point? FirstPoint { get; set; }
        public Point? SecondPoint { get; set; }
    }
}
