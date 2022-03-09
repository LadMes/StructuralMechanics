using Microsoft.AspNetCore.Identity;

namespace StructuralMechanics.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Project>? Projects { get; set; }
    }
}
