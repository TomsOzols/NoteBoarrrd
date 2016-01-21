using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteBoarrd.Models;
using NoteBoarrd.Queries;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Resources.Res;

namespace NoteBoarrd.Controllers
{

    public class BoardHub : Hub
    {
        public async Task JoinBoard(int boardId)
        {
            await Groups.Add(Context.ConnectionId, boardId.ToString());
        }

        public void MoveNote(int boardId, int noteId, float left, float top)
        {
            bool wasUpdated = BoardQueries.UpdateNoteCoord(noteId, left, top);
            if (wasUpdated)
            {
                Clients.OthersInGroup(boardId.ToString()).moveClientNote(noteId, left, top);
            }
        }

        //public static void RedirectOtherUsers(int boardId)
        //{
        //    Clients.OthersInGroup(boardId.ToString()).redirectClient();
        //}
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

        [HttpPost]
        public ActionResult DeleteBoard(int? id)
        {
            ApplicationUser user = AccountQueries.GetCurrentUser(User.Identity.Name);
            bool success = BoardQueries.DeleteBoard(user, (int)id);
            if (success)
            {
                string boardSuccesfullyDeleted = WebResources.BoardDeleteSuccess;
                return Json(new { success = true, message = boardSuccesfullyDeleted });
            }

            string boardDeletionFailed = WebResources.BoardDeleteFailure;
            return Json(new { success = false, message = boardDeletionFailed });
        }

        //[HttpPost]
        //public ActionResult PostPictureNote(int? id, byte[] image)
        //{
        //    NoteModel note = new NoteModel()
        //    {
        //        Type = "Image",
        //        BoardId = (int)id,
        //        left = 0,
        //        top = 0,
        //        Image = image
        //    };
        //    int noteId = BoardQueries.AddNewNote((int)id, note);
        //    return Json( new { id = noteId });
        //}

        [HttpPost]
        public ActionResult PostNote(int? id, string text, string type, byte[] image)
        {
            NoteModel note = new NoteModel()
            {
                Type = type,
                BoardId = (int)id,
                left = 0,
                top = 0
            };
            switch (type)
            {
                case "Text":
                    {
                        note.Text = text;
                        break;
                    }
                case "Image":
                    {
                        note.Image = image;
                        break;
                    }
                default:
                    {
                        return Json(new { success = false });
                    }
            }
            int noteId = BoardQueries.AddNewNote((int)id, note);
            return Json(new { success = true, id = noteId });
        }
    }
}