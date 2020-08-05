using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MostafaKhalafFullStack.Model;
using MostafaKhalafFullStack.ViewModel;

namespace MostafaKhalafFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private IConfiguration _config;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<AccountController> logger;

        public UserAccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger, IConfiguration config)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            _config = config;
        }






        /// <summary>
        //[AllowAnonymous]
        [HttpPost]
        [Route("Login")]

        public IActionResult Login([FromBody]LoginViewModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != false)
            {
                var tokenString = GenerateJSONWebToken();
                response = Ok(new { token = tokenString, user = login });
            }

            return response;
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool AuthenticateUser(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {

                var user = userManager.FindByEmailAsync(login.Email).ToAsyncEnumerable().First();
                user.Result.EmailConfirmed = true;

                if (user == null)
                {
                    //ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return false; //Ok(login);
                }

                var re = userManager.CheckPasswordAsync(user.Result, login.Password);
                if (re.IsCompletedSuccessfully)
                {
                    return true;
                }

                var result = signInManager.PasswordSignInAsync(user.Result, login.Password, true, true);

                if (result.IsCompletedSuccessfully)
                {
                    return true;
                }
                else
                    return false;


            }
            return false;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Age = model.Age,
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    UserName = model.Email,
                    EmailConfirmed=true,
                    

            };

                var result = userManager.CreateAsync(user, model.Password);
                //var m = result.AsyncState;
                if (result.Result.Succeeded)
                {

                    return Ok(true);
                }

                return BadRequest();
            }

            return BadRequest();

        }
    }
}