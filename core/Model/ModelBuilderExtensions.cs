using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MostafaKhalafFullStack.Model
{
    public static class ModelBuilderExtensions
    {
        public static void SeedUsers
     (UserManager<ApplicationUser> userManager)
        {

            if (userManager.FindByNameAsync
        ("alikhalaf").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "alikhalaf";
                user.Email = "mostafa@yahoo.com";
                user.FullName = "alikhalaf";
                user.BirthDate = new DateTime(1995, 1, 1);
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync
                (user, "mM@123456").Result;

             
            }


            if (userManager.FindByNameAsync
        ("aliahmed").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "aliahmed";
                user.Email = "aliahmed@yahh.com";
                user.FullName = "ahmedali";
                user.BirthDate = new DateTime(1999, 1, 1);
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync
                (user, "mM@123456").Result;

            
            }
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
                  new ApplicationUser
                  {
                      FullName = "mostafakhalaf",
                      Age = 25,
                      BirthDate = System.DateTime.Now,
                      Gender = "male"
                    },
                    new ApplicationUser
                    {

                        FullName = "htem",
                        Age = 25,
                        BirthDate = System.DateTime.Now,
                         Gender = "female"

                    }
                );
        }
    }
}
