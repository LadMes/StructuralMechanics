using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public abstract class VectorPhysicalQuantity
    {
        public int Id { get; set; }
        [Required]
        public double Magnitude { get; set; }
        [Required]
        public Direction Direction { get; set; }
        [Required]
        public VectorType VectorType { get; set; }

        //Navigation Properties
        [Required]
        public Project Project { get; set; }


        public VectorPhysicalQuantity(double magnitude, Direction direction)
        {
            this.Magnitude = magnitude;
            this.Direction = direction;
        }
    }
}
