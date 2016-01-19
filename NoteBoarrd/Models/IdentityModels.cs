using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace NoteBoarrd.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<UserBoards> UserBoards { get; set; }
        public virtual ICollection<BoardModel> MyBoards { get; set; }
        public virtual ICollection<CommentModel> MyComments { get; set; }
        public string PreferredCulture { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
