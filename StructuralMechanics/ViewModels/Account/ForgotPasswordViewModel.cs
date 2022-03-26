using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
