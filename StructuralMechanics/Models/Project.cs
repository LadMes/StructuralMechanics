using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string ProjectName { get; set; }


        //Navigation Properties
        [Required]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public Structure Structure { get; set; }
    }
}
