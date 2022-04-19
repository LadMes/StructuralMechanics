using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public abstract class GeneralGeometryProperties : GeometryObject
    {
        [Required]
        public double FirstMomentOfArea { get; protected set; }
        [Required]
        public double SecondMomentOfArea { get; protected set; }
    }
}
