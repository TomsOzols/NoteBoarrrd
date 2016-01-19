using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteBoarrd.Models;
using NoteBoarrd.Queries;
using Microsoft.AspNet.SignalR;

namespace NoteBoarrd.Controllers
{

    public class BoardHub : Hub
    {
        public void MoveNote(NoteModel note)
        {
            int noteMoved = 1;
        }
    }

    [System.Web.Mvc.Authorize]
    public class BoardController : Controller
    {
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Hub");
            }
            //!! Add restrictions for users not allowed in a certain board.
            BoardModel currentBoard = BoardQueries.GetBoardInfo((int)id);
            if (currentBoard == null)
            {
                return RedirectToAction("Index", "Hub");
            }
            return View(currentBoard);
        }

        [HttpGet]
        public JsonResult GetNotes(int? id)
        {
            ICollection<NoteModel> notes = BoardQueries.GetBoardNotes((int)id);
            return Json(notes, JsonRequestBehavior.AllowGet);
        }
    }
}