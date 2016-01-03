using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;
using NoteBoarrd.Attributes;

namespace NoteBoarrd.Controllers
{
    [CultureSet]
    public class AccountController : Controller
    {
        // GET: Account
        //public ActionResult Index()
        //{
        //    return View();
        //}
       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Language(string name)
        {
            CultureSetAttribute.SavePreferredCulture(HttpContext.Response, name);
            return RedirectToAction("Login");
        }
    }
}