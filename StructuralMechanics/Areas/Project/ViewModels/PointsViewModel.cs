using Microsoft.AspNetCore.Mvc.Rendering;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class PointsViewModel
    {
        public int Id { get; set; }
        public SelectList? Points { get; set; }
    }
}
