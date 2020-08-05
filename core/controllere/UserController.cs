using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MostafaKhalafFullStack.Model;
using MostafaKhalafFullStack.Service.Iservice;
using MostafaKhalafFullStack.ViewModel;

namespace MostafaKhalafFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly IServiceUser UserServices;
        public UserController(IServiceUser UserServices, UserManager<ApplicationUser> userManage)
        {
            this.UserServices = UserServices;
            this.userManager = userManage;
        }
        // GET: api/User
        [HttpGet]
        [Route("getAllUser")]
        public IActionResult getAllUser()
        {
            return Ok(UserServices.GetAllUser());
        }
        // GET: api/User/5
        [HttpGet]
        [Route("getUser")]
        public IActionResult getUser(string id)
        {
            return Ok(UserServices.GetByIDUser(id));
        }

        // POST: api/User
        [HttpPost]
        [Route("creatUser")]
        public IActionResult creatUser([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        FullName = model.FullName,
                        BirthDate = model.BirthDate,
                        Email = model.Email,
                        Age = model.Age,
                        Gender = model.Gender,
                        EmailConfirmed = true,
                        UserName=model.Email

                    };
                    var result = userManager.CreateAsync(user, model.Password);
                    //var m = result.AsyncState;
                    if (result.Result.Succeeded)
                    {

                        UserServices.PostUser(user);
                        return Ok();

                    }

                    // TODO: Add insert logic here
                    else 
                    return BadRequest();

                }
                catch
                {

                    return Ok(model);
                }

            }
            else

                return Ok(model);
        }

   

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("updateUser")]
        public IActionResult updateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = userManager.FindByEmailAsync(model.Email).ToAsyncEnumerable().First();

                    user.Result.FullName = model.FullName;
                    user.Result.BirthDate = model.BirthDate;
                    user.Result.Email = model.Email;
                    user.Result.Age = model.Age;
                    user.Result.Gender = model.Gender;
                    user.Result.EmailConfirmed = true;
                    
                        UserServices.EditUser(user.Result);
                        

                    

                    // TODO: Add insert logic here
                    
                        return Ok();

                }
                catch
                {

                    return Ok(model);
                }

            }
            else

                return Ok(model);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("deleteUser")]
        public IActionResult deleteUser(string id)
        {
            try
            {

                var model = UserServices.GetByIDUser(id);
                UserServices.DeleteUser(model);

                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
