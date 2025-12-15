using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels.Users
{
    public class ResetPasswordWithCodeVm
    {
   [Required(ErrorMessage = "Email is required")]
     [EmailAddress]
   public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Code is required")]
        [Display(Name = "Verification Code")]
        public string Code { get; set; } = string.Empty;

     [Required(ErrorMessage = "Password is required")]
   [StringLength(100, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
      public string NewPassword { get; set; } = string.Empty;

     [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
