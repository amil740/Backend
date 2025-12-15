using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels.Users
{
    public class ForgotPasswordVm
    {
   [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;
    }
}
