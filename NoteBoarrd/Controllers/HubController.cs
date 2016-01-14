using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoteBoarrd.Queries;
using NoteBoarrd.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NoteBoarrd.Controllers
{
    [Authorize]
    public class HubController : Controller
    {
        public ActionResult Index()
        {
            //!!Add Signal-R updates for everyone
            BoardListModel boards = new BoardListModel();
            boards.BoardList = HubQueries.GetAllPublicBoards();
            boards.NewBoardModel = new BoardModel();

            return View(boards);
        }

        [HttpPost]
        public ActionResult CreateBoard(BoardModel newBoard)
        {
            DateTime current = DateTime.Now;
            newBoard.LastChanged = current;
            newBoard.Created = current;
            newBoard.Notes = new Collection<NoteModel>();
            if (newBoard.Password != null)
            {
                newBoard.IsPasswordProtected = true;
            }
            else
            {
                newBoard.IsPasswordProtected = false;
            }
            int? newBoardId = HubQueries.AddBoard(newBoard);

            return RedirectToAction("Index", "Board", new { id = newBoardId });
        }
    }
}