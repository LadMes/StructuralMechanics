using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.ViewModels
{
    public class ProjectsViewModel
    {
        public string ProjectId { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Display(Name = "Structure Type")]
        public StructureType StructureType { get; set; }
        public int StructureId { get; set; }
    }
}
