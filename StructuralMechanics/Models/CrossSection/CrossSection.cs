using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public abstract class CrossSection
    {
        public int Id { get; set; }


        //Navigation Properties
        public int StructureId { get; set; }
        [Required]
        public Structure Structure { get; set; }
    }
}
