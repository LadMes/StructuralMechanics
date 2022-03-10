using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public abstract class GeneralGeometryProperties : GeometryObject
    {
        [Required]
        public double FirstMomentOfArea { get; set; }
        [Required]
        public double SecondMomentOfArea { get; set; }
    }
}
