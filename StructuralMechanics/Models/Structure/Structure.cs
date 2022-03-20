using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public abstract class Structure
    {
        public int Id { get; set; }
        [Display(Name = "Structure Type")]
        public StructureType StructureType { get; set; }

        //Navigation Properties
        public Guid ProjectId { get; set; }
        [Required]
        public Project Project { get; set; }
        //public List<GeometryObject>? GeometryObjects { get; set; }
        public List<Point>? Points { get; set; }
        public List<SimpleShape>? SimpleShapes { get; set; }
        public List<StrengthMember>? StrengthMembers { get; set; }
        public List<VectorPhysicalQuantity>? VectorPhysicalQuantities { get; set; }


        //For future
        //public List<Constraint> Constraints { get; set; }
    }
}
