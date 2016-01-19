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
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(WebResources))]
        [EmailAddress]
        [Display(ResourceType = typeof(WebResources), Name = "Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PassRequired", ErrorMessageResourceType = typeof(WebResources))]
        [StringLength(50, ErrorMessageResourceName = "PasswordLengthTooLow", ErrorMessageResourceType = typeof(WebResources), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(WebResources))]
        public string Password { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessageResourceName = "RepeatPassRequired", ErrorMessageResourceType = typeof(WebResources))]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(WebResources), Name = "RepeatPass")]
        [Compare("Password", ErrorMessageResourceName = "RepeatPassWrong", ErrorMessageResourceType = typeof(WebResources))]
        public string RepeatPassword { get; set; }
    }
}
