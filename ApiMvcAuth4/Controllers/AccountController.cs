#nullable enable
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiMvcAuth4.EmailService;
using ApiMvcAuth4.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiMvcAuth4.Controllers


{
    // MVC version
    public class AccountController : Controller
    {
        
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager , IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public  IActionResult Register()
        {
            return  View();
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistraionModel userModel)
        {
            if(!ModelState.IsValid)
            {
                return View(userModel);
            }
 
            var user = new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.Email
            }; 
            
            var result = await _userManager.CreateAsync(user, userModel.Password);
            
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
 
                return View(userModel);
            }
            
            
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);
 
            var message = new Message(new string[] { user.Email }, "Confirmation email link", confirmationLink, null);
            await _emailSender.SendEmailAsync(message);
            
 
            await _userManager.AddToRoleAsync(user, "Visitor");
 
            return RedirectToAction(nameof(SuccessRegistration));
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return View("Error");
 
            
            var result = await _userManager.ConfirmEmailAsync(user, token);
            await _userManager.SetTwoFactorEnabledAsync(user ,true);
            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }
 
        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string?  returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userModel , string? returnUrl)
        {
            if(!ModelState.IsValid)
            {
                return View(userModel);
            }
            
            
            var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, true);
            
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            
            // Added to active Lockout feature if the LockoutEnabled == 1 in DB
            if (result.IsLockedOut)
            {
                var forgotPassLink = Url.Action(nameof(ForgotPassword),"Account", new { }, Request.Scheme);
                var content = $"Your account is locked out, to reset your password, please click this link: {0} {forgotPassLink}";
 

                var message = new Message(new string[] { userModel.Email },"Locked out account information", content, null);
                await _emailSender.SendEmailAsync(message);
 
                ModelState.AddModelError("", "The account is locked out");
                return View();
            }
            
            // Added to active 2 step Verification if the TwoFactorEnabled == 1 in DB
            if(result.RequiresTwoFactor)
            {
                return RedirectToAction(nameof(LoginTwoStep), new { userModel.Email, userModel.RememberMe, returnUrl});
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
 
            
            
            // var user = await _userManager.FindByEmailAsync(userModel.Email);
            // if(user != null && await _userManager.CheckPasswordAsync(user, userModel.Password))
            // {
            //     var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            //     identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            //     identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            //
            //     await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));
            //
            //     return RedirectToLocal(returnUrl);
            // }
            // else
            // {
            //     ModelState.AddModelError("", "Invalid UserName or Password");
            //     return View();
            // }
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
 
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            if (!ModelState.IsValid) return View(forgotPasswordModel);
 
            var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user == null) return RedirectToAction(nameof(ForgotPasswordConfirmation));
 
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action( nameof(ResetPassword) , "Account", new { token, email = user.Email }, Request.Scheme);
 
            var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);
            await _emailSender.SendEmailAsync(message);
 
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }
        
        
        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ResetPassword(string token , string email)
        {
            var model = new ResetPasswordModel{Token = token , Email = email};
            return View(model);
        }
        
        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid) return View(resetPasswordModel);
 
            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null) RedirectToAction(nameof(ResetPasswordConfirmation));
 
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if(!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
 
                return View();
            }
 
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }
        
        
        
        
        
        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoginTwoStep(string email, bool rememberMe, string?  returnUrl )
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return View(nameof(Error));
            }
 
            var providers = await _userManager.GetValidTwoFactorProvidersAsync(user);
            if (!providers.Contains("Email"))
            {
                return View(nameof(Error));
            }
 
            var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
 
            var message = new Message(new string[] { user.Email }, "Authentication token", token, null);
            await _emailSender.SendEmailAsync(message);
 
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginTwoStep(TwoStepModel twoStepModel ,string?  returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(twoStepModel);
            }
 
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if(user == null)
            {
                return RedirectToAction(nameof(Error));
            }
 
            var result = await _signInManager.TwoFactorSignInAsync("Email", twoStepModel.TwoFactorCode, twoStepModel.RememberMe, rememberClient: false);
            if(result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else if(result.IsLockedOut)
            {
                //Same logic as in the Login action
                ModelState.AddModelError("", "The account is locked out");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Invalid Login Attempt");
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult ExternalLogin(string provider, string? returnUrl)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        
        
        

        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string? returnUrl)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }
 
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if(signInResult.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            if(signInResult.IsLockedOut)
            {
                return RedirectToAction(nameof(ForgotPassword));
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["Provider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginModel { Email = email });
            }
        }
        
        
        
        
        
        
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginModel model, string? returnUrl)
        {
            if (!ModelState.IsValid) return View("ExternalLogin",model);
            
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null) return View(nameof(Error));
 
            var user = await _userManager.FindByEmailAsync(model.Email);
            IdentityResult result;
 
            if(user != null)
            {
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
            }
            else
            {
                model.Principal = info.Principal;
                user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                    LastName = info.Principal.FindFirstValue(ClaimTypes.Surname)
                    
                }; 
                
                result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                       //Send an email for the email confirmation and add a default role as in the Register action
                       
                       var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                       var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);
 
                       var message = new Message(new string[] { user.Email }, "Confirmation email link", confirmationLink, null);
                       await _emailSender.SendEmailAsync(message);
                       

                       await _userManager.AddToRoleAsync(user, "Visitor");
                       return RedirectToAction(nameof(SuccessRegistration));
 
                        // await _signInManager.SignInAsync(user,false );
                        // return RedirectToLocal(returnUrl);
                    }
                }
            }
            
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
 
            return View(nameof(ExternalLogin), model);
        }





        [HttpGet]
        [Authorize]
        public IActionResult UserDelete()
        {
          return  View();
        }
        
        
        // Only if the All the Users Register without external providers because we check their password for deletion
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> UserDelete(UserDeleteModel userDeleteModel)
        {
            
            if (!ModelState.IsValid)
            {
                return View(userDeleteModel);
            }

            if (!_signInManager.IsSignedIn(User))
            {
                ModelState.AddModelError("", "you are not Authorize to this action!");
                return View();
            }
            
            // var user = await _userManager.FindByIdAsync(User.Identity.Name);
            // var user = await _userManager.FindByIdAsync(HttpContext.User.Identity.Name);
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var check = await _signInManager.UserManager.CheckPasswordAsync(user , userDeleteModel.Password);

            if (!check)
            {
                ModelState.AddModelError("", "The password is inconsistent !");
                // do more stuff ex: let the user know someone is trying to delete his/her account by the email
                return View();
            }
            
            await _signInManager.SignOutAsync();
            var result = await _userManager.DeleteAsync(user);
            
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(userDeleteModel);
            }
                                            
            ViewData["DeletedUser"] = user.UserName;
            return View(nameof(SuccessDeletion));
        }
        
        
        
        [HttpGet]
        public IActionResult SuccessDeletion()
        {
            return View();
        }
        
        
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
    
        }

        
        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }
    }
}