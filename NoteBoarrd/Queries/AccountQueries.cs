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
            ApplicationUser user = GetCurrentUser(currentUser);
            user.PreferredCulture = language;
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

        public static ICollection<BoardModel> GetLastVisitedBoards(string userName)
        {
            ApplicationUser user = GetCurrentUser(userName);
            using (var db = new ApplicationDbContext())
            {
                var query = db.UserBoards.Where(x => x.UserId == user.Id).OrderByDescending(x => x.LastVisited).Take(10).Select(x => x.Board).AsEnumerable();
                ICollection<BoardModel> boards = query.ToList();
                return boards;
            }
        }

        public static ICollection<BoardModel> GetMyBoards(string userName)
        {
            ApplicationUser user = GetCurrentUser(userName);
            using (var db = new ApplicationDbContext())
            {
                var query = db.Users.Where(x => x.Id == user.Id).Select(x => x.MyBoards);
                var boards = query.FirstOrDefault();
                return boards;
            }
        }

        public static ICollection<Culture> GetCultures()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Cultures;
                ICollection<Culture> cultures = query.ToList();
                return cultures;
            }
        }
    }
}