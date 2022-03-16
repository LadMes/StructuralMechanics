using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public abstract class GeometryObject
    {
        public int Id { get; set; }
        [Required]
        public GeometryType GeometryType { get; protected set; }


        //Navigation Properties
        [Required]
        public Structure Structure { get; set; }
    }
}
