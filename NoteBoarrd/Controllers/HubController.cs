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
        [HttpGet]
        public ActionResult Index()     //!!Feeling my bad architecture allready
        {
            //!!Add Signal-R updates for everyone
            //BoardListModel hub = new BoardListModel();
            IEnumerable<BoardModel> BoardList = HubQueries.GetAllPublicBoards();

            foreach(BoardModel board in BoardList)          //!!Figure out a better way someday
            {
                if (board.Password != null)
                {
                    board.IsPasswordProtected = true;
                }
            }

            return View(BoardList);
        }

        [HttpGet]
        public ActionResult CreateBoard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBoard(AddBoardModel board)
        {
            if (!ModelState.IsValid)
            {
                return View(board);
            }
            DateTime current = DateTime.Now;
            string userName = User.Identity.Name;
            BoardModel newBoard = new BoardModel()
            {
                LastChanged = current,
                Created = current,
                Notes = new Collection<NoteModel>(),
                Name = board.Name,
                Password = board.Password,
                IsPrivate = board.IsPrivate
            };
           
            //if (newBoard.Password != null)
            //{
            //    newBoard.IsPasswordProtected = true;
            //}
            //else
            //{
            //    newBoard.IsPasswordProtected = false;
            //}
            int? newBoardId = HubQueries.AddBoard(newBoard, userName);

            return RedirectToAction("Index", "Board", new { id = newBoardId });
        }
    }
}