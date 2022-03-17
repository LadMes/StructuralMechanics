using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public abstract class Structure
    {
        public int Id { get; set; }
        public StructureType StructureType { get; set; }

        //Navigation Properties
        [Required]
        public Project Project { get; set; }
        public List<GeometryObject>? GeometryObjects { get; set; }
        public List<VectorPhysicalQuantity>? VectorPhysicalQuantities { get; set; }
        //For future
        //public List<Constraint> Constraints { get; set; }
    }
}
