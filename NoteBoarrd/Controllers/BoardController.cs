using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteBoarrd.Models;
using NoteBoarrd.Queries;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace NoteBoarrd.Controllers
{

    public class BoardHub : Hub
    {
        public async Task JoinBoard(int boardId)
        {
            await Groups.Add(Context.ConnectionId, boardId.ToString());
        }

        public void MoveNote(NoteModel note, int boardId)
        {
            Clients.OthersInGroup(boardId.ToString()).moveClientNote(note);
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

            BoardQueries.UpdateBoardVisit((int)id, User.Identity.Name);
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