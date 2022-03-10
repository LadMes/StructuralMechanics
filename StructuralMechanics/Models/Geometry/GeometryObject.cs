using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public abstract class GeometryObject
    {
        public int Id { get; set; }
        [Required]
        protected GeometryType GeometryType { get; set; }


        //Navigation Properties
        [Required]
        public Project Project { get; set; }
    }
}
