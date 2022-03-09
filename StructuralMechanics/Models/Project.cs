using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string ProjectName { get; set; }
        //public List<Point>? Points { get; set; }
        //public List<BasicShape>? Shapes { get; set; }
        //public List<StrengthMember>? StrengthMembers { get; set; }
        //public List<ShearForce>? ShearForces { get; set; }
        //public List<Moment>? Moments { get; set; }

        //Navigation Properties
        //public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Geometry> Geometries { get; set; }
    }
}
