using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoarrd.Models
{
    public class AccountModels
    {
        public class LoginModel
        {
            [Required]
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
        }

        public class RegisterModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "")]
            public string Email { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "")]
            public string RepeatPassword { get; set; }
        }
    }
}
