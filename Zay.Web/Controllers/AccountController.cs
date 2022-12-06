using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zay.ApplicationCore.DTO;
using Zay.ApplicationCore.Entities;
using Zay.ApplicationCore.Interfaces;
using Zay.Infrastructure.Models;

namespace Zay.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public ViewResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = user.Username,
                    Email = user.Email
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    TempData["Message"] = "User Created Successfully";
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel user, string returnurl)
        {
            if (!string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
            {
                ApplicationUser appUser = await _userManager.FindByEmailAsync(user.Email);
                if (appUser != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, user.Password, false, false);
                    if (result.Succeeded)
                        return Redirect(returnurl ?? "/home");
                }
                ModelState.AddModelError("", "Login Failed: Invalid Email or Password");
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
