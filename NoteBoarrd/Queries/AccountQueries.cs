using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteBoarrd.Queries
{
    public static class AccountQueries
    {
        public static void ChangeLanguagePreference(string currentUser, string language)
        {
            
            using (var db = new ApplicationDbContext())
            {
                //db.UserPreferences.Attach();
            }
        }
    }
}