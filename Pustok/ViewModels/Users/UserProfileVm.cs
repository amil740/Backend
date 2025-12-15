using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels.Users
{
    public class UserProfileVm
    {
   public string Id { get; set; } = string.Empty;

   [Required(ErrorMessage = "Full name is required")]
        [StringLength(100, MinimumLength = 2)]
 [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

 [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
   [Display(Name = "Email")]
  public string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = "Username is required")]
 [StringLength(50, MinimumLength = 3)]
   [Display(Name = "Username")]
        public string Username { get; set; } = string.Empty;

        [Phone]
   [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; }
   public DateTime CreatedDate { get; set; }
 }
}
