using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.ViewModels
{
    public class ProjectViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; } = "";

        [Required]
        [Display(Name = "Structure Type")]
        public StructureType StructureType { get; set; }
        public bool IsCreateView { get; set; }

        [Display(Name = "Thin-Walled Structure Type")]
        public ThinWalledStructureType? ThinWalledStructureType { get; set; }
    }
}
