using Microsoft.AspNetCore.Mvc.Rendering;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public class PointsViewModel : BaseViewModel
    {
        public SelectList? Points { get; set; }
    }
}
