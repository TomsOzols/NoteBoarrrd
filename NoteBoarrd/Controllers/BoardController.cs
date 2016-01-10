using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteBoarrd.Models;
using NoteBoarrd.Queries;

namespace NoteBoarrd.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        // GET: Board
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
    }
}