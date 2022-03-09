using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.Models
{
    public class GeometryObject
    {
        public int Id { get; set; }
        protected GeometryType GeometryType { get; set; }


        //Navigation Properties
        public Project Project { get; set; }
    }
}
