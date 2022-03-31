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
        public VectorType VectorType { get; protected set; }

        //Navigation Properties
        [Required]
        public int StructureId { get; set; }
        public Structure Structure { get; set; }


        public VectorPhysicalQuantity(double magnitude, Direction direction)
        {
            this.Magnitude = magnitude;
            this.Direction = direction;
        }
    }
}
