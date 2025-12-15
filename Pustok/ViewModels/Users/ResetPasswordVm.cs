using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels.Users
{
    public class ResetPasswordVm
    {
        [Required]
      public string UserId { get; set; } = string.Empty;

 [Required]
        public string Token { get; set; } = string.Empty;

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
