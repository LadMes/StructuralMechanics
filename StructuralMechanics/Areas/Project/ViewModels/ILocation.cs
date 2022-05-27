using Microsoft.AspNetCore.Mvc.Rendering;

namespace StructuralMechanics.Areas.Project.ViewModels
{
    public interface ILocation
    {
        public SelectList? Points { get; set; }
        public int LocationId { get; set; }
        public Point? Location { get; set; }
    }
}
