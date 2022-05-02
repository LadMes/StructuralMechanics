using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models.CrossSection
{
    public abstract class CrossSectionElement
    {
        public int Id { get; set; }
        [Required]
        public CrossSectionElementType ElementType { get; protected set; }


        public int StructureId { get; set; }
        [Required]
        public Structure Structure { get; set; }
    }
}
