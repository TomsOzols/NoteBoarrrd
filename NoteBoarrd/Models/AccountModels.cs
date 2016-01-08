using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Res;

namespace NoteBoarrd.Models
{
    public class LoginModel
    {
        [Required]
        [Display(ResourceType = typeof(WebResources), Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(WebResources), Name = "Password")]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(WebResources), Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessageResourceName = "PasswordLengthTooLow", ErrorMessageResourceType = typeof(WebResources), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(WebResources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(WebResources), Name = "RepeatPass")]
        public string RepeatPassword { get; set; }
    }
}
