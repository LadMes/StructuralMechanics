using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.Structures
{
    public abstract class Structure
    {
        public int Id { get; set; }
        [Display(Name = "Structure Type")]
        public StructureType Type { get; set; }

        //Navigation Properties
        public string ProjectId { get; set; }
        [Required]
        public Project Project { get; set; }
        public List<CrossSectionElement>? CrossSectionElements { get; set; }
        public List<VectorPhysicalQuantity>? VectorPhysicalQuantities { get; set; }


        //For future
        //public List<Constraint>? Constraints { get; set; }
    }
}
