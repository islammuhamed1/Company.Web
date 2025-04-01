using Company.Data.Entities;
using Company.Service.Helper;
using Company.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Company.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #region SignUp
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = input.Email.Split('@')[0],
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    IsActive = true
                };
                var result = (await _userManager.CreateAsync(user, input.Password));
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(input);

            }
            return View(input);
        }
        #endregion
        #region SignIn
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel signIn)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(signIn.Email);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, signIn.Password))
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, signIn.Password, signIn.RememberMe, true);
                        if (result.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, signIn.RememberMe);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                            ModelState.AddModelError("", "Invalid Login Attempt");
                        return View(signIn);
                    }
                }
            }
            return View(signIn);
        }
        #endregion
        #region SignOut
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        #endregion
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(forgetPassword.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callbackUrl = Url.Action("ResetPassword", "Account", 
                        new {Token = token,Email = forgetPassword.Email }, Request.Scheme);
                    var email = new Email
                    {
                        Body = callbackUrl,
                        To = forgetPassword.Email,
                        Subject = "Reset Password"
                    };
                    EmailSettings.SendEmail(email);
                    //Send Email
                    return RedirectToAction("CheckYourinbox");
                }
            }
            return View(forgetPassword);
        }
        public IActionResult CheckYourinbox()
        {
            return View();
        }
        public IActionResult ResetPassword(string email , string token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>ResetPassword(ResetPasswordViewModel resetPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(resetPassword.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(resetPassword);
                }
            }
            return View(resetPassword);
        }
    }
}
