using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MostafaKhalafFullStack.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string FullName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        [EmailAddress]
        
        public string Email { get; set; }


    }
}
