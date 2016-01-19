using NoteBoarrd.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteBoarrd.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdatePreferences()
        {
            //string userName = User.Identity.Name;
            //AccountQueries.ChangeLanguagePreference(userName, culture);

            return RedirectToAction("Index");       //Make this return to the view where user preferences are.
        }
    }
}