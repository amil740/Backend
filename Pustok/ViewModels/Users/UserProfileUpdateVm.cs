using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels.Users
{
    public class UserProfileUpdateVm
    {
  [Required(ErrorMessage = "Full name is required")]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
   [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email")]
     public string Email { get; set; } = string.Empty;

        [Phone]
   [Display(Name = "Phone Number")]
   public string? PhoneNumber { get; set; }

        [DataType(DataType.Password)]
   [Display(Name = "Current Password")]
   public string? CurrentPassword { get; set; }

        [StringLength(100, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
   public string? NewPassword { get; set; }

 [DataType(DataType.Password)]
 [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
