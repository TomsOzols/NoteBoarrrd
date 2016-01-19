using NoteBoarrd.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteBoarrd.Models;
using NoteBoarrd.Attributes;

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

        [HttpGet]
        public ActionResult UserPreferences()
        {
            ApplicationUser user = AccountQueries.GetCurrentUser(User.Identity.Name);
            PreferencesModel preferences = new PreferencesModel()
            {
                cultures = AccountQueries.GetCultures().ToList()
            };

            return View(preferences);
        }

        [HttpPost]
        public ActionResult UserPreferences(PreferencesModel model)
        {
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                string prefferedCulture = model.cultures.Where(x => x.Id == model.CultureIdentifier).Select(x => x.CultureTag).SingleOrDefault();
                AccountQueries.ChangeLanguagePreference(userName, prefferedCulture);
                CultureSetAttribute.SavePreferredCulture(HttpContext.Response, prefferedCulture);
            }

            return View(model);
        }
    }
}