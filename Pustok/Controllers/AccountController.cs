using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pustok.Models;
using Pustok.ViewModels.Users;

namespace Pustok.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register(string? returnUrl = null)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterVm model)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FullName = model.FullName,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: model.RememberMe);
                    TempData["SuccessMessage"] = "Registration successful!";

                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginVm model)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                AppUser? user = null;

                if (model.UsernameOrEmail.Contains("@"))
                {
                    user = await _userManager.FindByEmailAsync(model.UsernameOrEmail);
                }
                else
                {
                    user = await _userManager.FindByNameAsync(model.UsernameOrEmail);
                }

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid username/email or password");
                    return View(model);
                }

                if (!user.IsActive)
                {
                    ModelState.AddModelError(string.Empty, "Your account has been deactivated");
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Login successful!";

                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Your account has been locked out. Please try again later.");
                    return View(model);
                }

                ModelState.AddModelError(string.Empty, "Invalid username/email or password");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["SuccessMessage"] = "You have been logged out successfully";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVm model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    TempData["SuccessMessage"] = "If your email exists in our system, you will receive a password reset link";
                    return RedirectToAction("Login");
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                TempData["SuccessMessage"] = "Password reset link has been sent to your email";
                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null)
            {
                return NotFound();
            }

            var model = new UserProfileVm
            {
                FullName = user.FullName,
                Email = user.Email!,
                Username = user.UserName!,
                PhoneNumber = user.PhoneNumber,
                CreatedDate = user.CreatedDate
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(UserProfileUpdateVm model, string? CurrentPassword, string? NewPassword, string? ConfirmPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
                if (user == null)
                {
                    return NotFound();
                }

                user.FullName = model.FullName;
                user.PhoneNumber = model.PhoneNumber;

                if (!string.IsNullOrEmpty(model.Email) && model.Email != user.Email)
                {
                    var emailExists = await _userManager.FindByEmailAsync(model.Email);
                    if (emailExists != null && emailExists.Id != user.Id)
                    {
                        ModelState.AddModelError("Email", "This email is already in use");
                        return View("EditProfile", model);
                    }
                    user.Email = model.Email;
                }

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    // Handle password change if provided
                    if (!string.IsNullOrEmpty(CurrentPassword) && !string.IsNullOrEmpty(NewPassword))
                    {
                        if (NewPassword != ConfirmPassword)
                        {
                            ModelState.AddModelError(string.Empty, "New password and confirmation do not match");
                            return View("EditProfile", model);
                        }

                        var passwordChangeResult = await _userManager.ChangePasswordAsync(user, CurrentPassword, NewPassword);

                        if (!passwordChangeResult.Succeeded)
                        {
                            foreach (var error in passwordChangeResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        return View("EditProfile", model);
                         }
        
                       TempData["SuccessMessage"] = "Profile and password updated successfully!";
                      }
                    else
                    {
                       TempData["SuccessMessage"] = "Profile updated successfully!";
                     }
            
                    return RedirectToAction("MyAccount");
                 }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View("EditProfile", model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyAccount()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null)
            {
                return NotFound();
            }

            var model = new UserProfileVm
            {
                FullName = user.FullName,
                Email = user.Email!,
                Username = user.UserName!,
                PhoneNumber = user.PhoneNumber,
                CreatedDate = user.CreatedDate
            };

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null)
            {
                return NotFound();
            }

            var model = new UserProfileUpdateVm
            {
                FullName = user.FullName,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber
            };

            return View(model);
        }
    }
}
