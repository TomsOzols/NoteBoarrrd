using NoteBoarrd.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteBoarrd.Models;

namespace NoteBoarrd.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            UserPageViewModel model = new UserPageViewModel();
            model.VisitedBoards = AccountQueries.GetLastVisitedBoards(User.Identity.Name);
            model.MyBoards = AccountQueries.GetMyBoards(User.Identity.Name);
            return View(model);
        }

        public ActionResult UpdatePreferences()
        {
            //string userName = User.Identity.Name;
            //AccountQueries.ChangeLanguagePreference(userName, culture);

            return RedirectToAction("Index");       //Make this return to the view where user preferences are.
        }
    }
}