using Microsoft.AspNetCore.Mvc.Rendering;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class PointsViewModel : CrossSectionElementViewModel
    {
        public SelectList? Points { get; set; }
    }
}
