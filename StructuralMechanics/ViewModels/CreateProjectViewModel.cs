using StructuralMechanics.Models;
using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.ViewModels
{
    public class CreateProjectViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public Structure Structure { get; set; }
        public ThinWalledStructure? ThinWalledStructure { get; set; }

        //For future
        //public CirclePlate? CirclePlate { get; set; }
        //public RotationalShell? RotationalShell { get; set; }
    }
}
