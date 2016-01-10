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
        // GET: Hub
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BoardList()
        {
            //!!Add Signal-R updates for everyone
            ICollection<BoardListElement> boards = HubQueries.GetAllPublicBoards();

            return View(boards);
        }

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
            newBoard.Rights = new BoardRights();

            int newBoardId = HubQueries.AddBoard(newBoard);

            return View("Index", "Board", newBoardId);
        }
    }
}