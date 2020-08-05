
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MostafaKhalafFullStack.Model;
using MostafaKhalafFullStack.ViewModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace MostafaKhalafFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private IConfiguration _config;
        //private readonly UserManager<ApplicationUser> userManager;
        //private readonly SignInManager<ApplicationUser> signInManager;
        //private readonly ILogger<AccountController> logger;

        //public AccountController(UserManager<ApplicationUser> userManager,
        //    SignInManager<ApplicationUser> signInManager,
        //    ILogger<AccountController> logger, IConfiguration config)
        //{
        //    this.userManager = userManager;
        //    this.signInManager = signInManager;
        //    this.logger = logger;
        //    _config = config;
        //}






        ///// <summary>
        //[AllowAnonymous]
        //[Route("Login")]
        //[HttpPost]
        //public IActionResult Login([FromBody]LoginViewModel login)
        //{
        //    IActionResult response = Unauthorized();
        //    var user = AuthenticateUser(login);

        //    if (user != false)
        //    {
        //        var tokenString = GenerateJSONWebToken();
        //        response = Ok(new { token = tokenString,user=login});
        //    }

        //    return response;
        //}

        //private string GenerateJSONWebToken()
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Issuer"],
        //      null,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //private bool AuthenticateUser(LoginViewModel login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = userManager.FindByEmailAsync(login.Email);
        //        if (user == null )
        //        {
        //            //ModelState.AddModelError(string.Empty, "Email not confirmed yet");
        //            return false; //Ok(login);
        //        }
        //        //var result = signInManager.PasswordSignInAsync(login.Email, login.FullName);
        //        //if (result.IsCompletedSuccessfully)
        //        //{
        //        //    return true;
        //        //}


        //    }
        //    return true;
        //}

        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[AllowAnonymous]
        //[Route("AddPassword")]
        //public async Task<IActionResult> AddPassword()
        //{
        //    var user = await userManager.GetUserAsync(User);

        //    var userHasPassword = await userManager.HasPasswordAsync(user);

        //    if (userHasPassword)
        //    {
        //        return RedirectToAction("ChangePassword");
        //    }

        //    return Ok();
        //}

        ////[HttpPost]
        ////public async Task<IActionResult> AddPassword(AddPasswordViewModel model)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        var user = await userManager.GetUserAsync(User);

        ////        var result = await userManager.AddPasswordAsync(user, model.NewPassword);

        ////        if (!result.Succeeded)
        ////        {
        ////            foreach (var error in result.Errors)
        ////            {
        ////                ModelState.AddModelError(string.Empty, error.Description);
        ////            }
        ////            return View();
        ////        }

        ////        await signInManager.RefreshSignInAsync(user);

        ////        return View("AddPasswordConfirmation");
        ////    }

        ////    return View(model);
        ////}

        //[HttpGet]
        //public async Task<IActionResult> ChangePassword()
        //{
        //    var user = await userManager.GetUserAsync(User);

        //    var userHasPassword = await userManager.HasPasswordAsync(user);

        //    if (!userHasPassword)
        //    {
        //        return RedirectToAction("AddPassword");
        //    }

        //    return Ok();
        //}

        ////[HttpPost]
        ////public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        var user = await userManager.GetUserAsync(User);
        ////        if (user == null)
        ////        {
        ////            return RedirectToAction("Login");
        ////        }

        ////        var result = await userManager.ChangePasswordAsync(user,
        ////            model.CurrentPassword, model.NewPassword);

        ////        if (!result.Succeeded)
        ////        {
        ////            foreach (var error in result.Errors)
        ////            {
        ////                ModelState.AddModelError(string.Empty, error.Description);
        ////            }
        ////            return View();
        ////        }

        ////        await signInManager.RefreshSignInAsync(user);
        ////        return View("ChangePasswordConfirmation");
        ////    }

        ////    return View(model);
        ////}

        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult ResetPassword(string token, string email)
        //{
        //    if (token == null || email == null)
        //    {
        //        ModelState.AddModelError("", "Invalid password reset token");
        //    }
        //    return Ok();
        //}

        ////[HttpPost]
        ////[AllowAnonymous]
        ////public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        var user = await userManager.FindByEmailAsync(model.Email);

        ////        if (user != null)
        ////        {
        ////            var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
        ////            if (result.Succeeded)
        ////            {
        ////                if (await userManager.IsLockedOutAsync(user))
        ////                {
        ////                    await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow);
        ////                }

        ////                return View("ResetPasswordConfirmation");
        ////            }

        ////            foreach (var error in result.Errors)
        ////            {
        ////                ModelState.AddModelError("", error.Description);
        ////            }
        ////            return View(model);
        ////        }

        ////        return View("ResetPasswordConfirmation");
        ////    }

        ////    return View(model);
        ////}

        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult ForgotPassword()
        //{
        //    return Ok();
        //}

        ////[HttpPost]
        ////[AllowAnonymous]
        ////public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        var user = await userManager.FindByEmailAsync(model.Email);

        ////        if (user != null && await userManager.IsEmailConfirmedAsync(user))
        ////        {
        ////            var token = await userManager.GeneratePasswordResetTokenAsync(user);

        ////            var passwordResetLink = Url.Action("ResetPassword", "Account",
        ////                    new { email = model.Email, token = token }, Request.Scheme);

        ////            logger.Log(LogLevel.Warning, passwordResetLink);

        ////            return View("ForgotPasswordConfirmation");
        ////        }

        ////        return View("ForgotPasswordConfirmation");
        ////    }

        ////    return View(model);
        ////}

        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();
        //    return RedirectToAction("index", "home");
        //}

        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult Register()
        //{
        //    return Ok();
        //}

        //[AcceptVerbs("Get", "Post")]
        //[AllowAnonymous]
        //public async Task<IActionResult> IsEmailInUse(string email)
        //{
        //    var user = await userManager.FindByEmailAsync(email);

        //    if (user == null)
        //    {
        //        return Ok(true);
        //    }
        //    else
        //    {
        //        return Ok($"Email {email} is already in use");
        //    }
        //}

        ////[HttpPost]
        ////[AllowAnonymous]
        ////public async Task<IActionResult> Register(RegisterViewModel model)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        var user = new ApplicationUser
        ////        {
        ////            UserName = model.Email,
        ////            Email = model.Email,
        ////            City = model.City
        ////        };

        ////        var result = await userManager.CreateAsync(user, model.Password);

        ////        if (result.Succeeded)
        ////        {
        ////            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

        ////            var confirmationLink = Url.Action("ConfirmEmail", "Account",
        ////                                    new { userId = user.Id, token = token }, Request.Scheme);

        ////            logger.Log(LogLevel.Warning, confirmationLink);

        ////            if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
        ////            {
        ////                return RedirectToAction("ListUsers", "Administration");
        ////            }

        ////            ViewBag.ErrorTitle = "Registration successful";
        ////            ViewBag.ErrorMessage = "Before you can Login, please confirm your " +
        ////                "email, by clicking on the confirmation link we have emailed you";
        ////            return View("Error");
        ////        }

        ////        foreach (var error in result.Errors)
        ////        {
        ////            ModelState.AddModelError(string.Empty, error.Description);
        ////        }
        ////    }

        ////    return View(model);
        ////}

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> ConfirmEmail(string userId, string token)
        //{
        //    if (userId == null || token == null)
        //    {
        //        return RedirectToAction("index", "home");
        //    }

        //    var user = await userManager.FindByIdAsync(userId);

        //    if (user == null)
        //    {
        //        //ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
        //        return Ok("NotFound");
        //    }

        //    var result = await userManager.ConfirmEmailAsync(user, token);

        //    if (result.Succeeded)
        //    {
        //        return Ok();
        //    }

        //    //ViewBag.ErrorTitle = "Email cannot be confirmed";
        //    return Ok("Error");
        //}

        ////[HttpGet]
        ////[AllowAnonymous]
        ////public async Task<IActionResult> Login(string returnUrl)
        ////{
        ////    LoginViewModel model = new LoginViewModel
        ////    {
        ////        ReturnUrl = returnUrl,
        ////        ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
        ////    };

        ////    return View(model);
        ////}

        ////[HttpPost]
        ////[AllowAnonymous]
        ////public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        ////{
        ////    model.ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        ////    if (ModelState.IsValid)
        ////    {
        ////        var user = await userManager.FindByEmailAsync(model.Email);

        ////        if (user != null && !user.EmailConfirmed &&
        ////                            (await userManager.CheckPasswordAsync(user, model.Password)))
        ////        {
        ////            ModelState.AddModelError(string.Empty, "Email not confirmed yet");
        ////            return View(model);
        ////        }

        ////        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,
        ////                                model.RememberMe, true);

        ////        if (result.Succeeded)
        ////        {
        ////            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
        ////            {
        ////                return Redirect(returnUrl);
        ////            }
        ////            else
        ////            {
        ////                return RedirectToAction("index", "home");
        ////            }
        ////        }

        ////        if(result.IsLockedOut)
        ////        {
        ////            return View("AccountLocked");
        ////        }

        ////        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        ////    }

        ////    return View(model);
        ////}

        ////[AllowAnonymous]
        ////[HttpPost]
        ////public IActionResult ExternalLogin(string provider, string returnUrl)
        ////{
        ////    var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
        ////                            new { ReturnUrl = returnUrl });

        ////    var properties =
        ////        signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

        ////    return new ChallengeResult(provider, properties);
        ////}

        ////[AllowAnonymous]
        ////public async Task<IActionResult>
        ////    ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        ////{
        ////    returnUrl = returnUrl ?? Url.Content("~/");

        ////    LoginViewModel loginViewModel = new LoginViewModel
        ////    {
        ////        ReturnUrl = returnUrl,
        ////        ExternalLogins =
        ////        (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
        ////    };

        ////    if (remoteError != null)
        ////    {
        ////        ModelState.AddModelError(string.Empty,
        ////            $"Error from external provider: {remoteError}");

        ////        return View("Login", loginViewModel);
        ////    }

        ////    var info = await signInManager.GetExternalLoginInfoAsync();
        ////    if (info == null)
        ////    {
        ////        ModelState.AddModelError(string.Empty,
        ////            "Error loading external login information.");

        ////        return View("Login", loginViewModel);
        ////    }

        ////    var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        ////    ApplicationUser user = null;

        ////    if (email != null)
        ////    {
        ////        user = await userManager.FindByEmailAsync(email);

        ////        if (user != null && !user.EmailConfirmed)
        ////        {
        ////            ModelState.AddModelError(string.Empty, "Email not confirmed yet");
        ////            return View("Login", loginViewModel);
        ////        }
        ////    }

        ////    var signInResult = await signInManager.ExternalLoginSignInAsync(
        ////                                info.LoginProvider, info.ProviderKey,
        ////                                isPersistent: false, bypassTwoFactor: true);

        ////    if (signInResult.Succeeded)
        ////    {
        ////        return LocalRedirect(returnUrl);
        ////    }
        ////    else
        ////    {
        ////        if (email != null)
        ////        {
        ////            if (user == null)
        ////            {
        ////                user = new ApplicationUser
        ////                {
        ////                    UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
        ////                    Email = info.Principal.FindFirstValue(ClaimTypes.Email)
        ////                };

        ////                await userManager.CreateAsync(user);

        ////                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

        ////                var confirmationLink = Url.Action("ConfirmEmail", "Account",
        ////                                new { userId = user.Id, token = token }, Request.Scheme);

        ////                logger.Log(LogLevel.Warning, confirmationLink);

        ////                ViewBag.ErrorTitle = "Registration successful";
        ////                ViewBag.ErrorMessage = "Before you can Login, please confirm your " +
        ////                    "email, by clicking on the confirmation link we have emailed you";
        ////                return View("Error");
        ////            }

        ////            await userManager.AddLoginAsync(user, info);
        ////            await signInManager.SignInAsync(user, isPersistent: false);

        ////            return LocalRedirect(returnUrl);
        ////        }

        ////        ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
        ////        ViewBag.ErrorMessage = "Please contact support on Pragim@PragimTech.com";

        ////        return View("Error");
        ////    }
        ////}
    }
}