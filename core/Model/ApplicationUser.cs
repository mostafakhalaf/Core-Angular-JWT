using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MostafaKhalafFullStack.Model
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
         public string Gender { get; set; }
        

    }
}
