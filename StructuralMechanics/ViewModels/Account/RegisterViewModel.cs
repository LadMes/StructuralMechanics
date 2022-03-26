using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StructuralMechanics.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote("IsEmailInUse", "Account")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The fields Password and Confirm Password must match!")]
        public string ConfirmPassword { get; set; }
    }
}
