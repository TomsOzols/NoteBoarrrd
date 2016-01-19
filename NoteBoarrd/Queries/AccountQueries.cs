using NoteBoarrd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace NoteBoarrd.Queries
{
    public static class AccountQueries
    {
        public static void ChangeLanguagePreference(string currentUser, string language)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = currentUser,
                PreferredCulture = language
            };
            using (var db = new ApplicationDbContext())
            {
                db.Users.Attach(user);
                var entry = db.Entry(user);
                entry.Property(x => x.PreferredCulture).IsModified = true;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// This is probably a very bad practice.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static ApplicationUser GetCurrentUser(string userName)
        {
            ApplicationUser user = null;
            using (var db = new ApplicationDbContext())
            {
                user = db.Users.Where(x => x.UserName == userName).FirstOrDefault();
            }
            return user;
        }
    }
}