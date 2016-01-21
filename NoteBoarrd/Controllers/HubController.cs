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
        public ActionResult Index(string message = null)
        {
            //!!Add Signal-R updates for everyone
            HubModel model = new HubModel();
            model.BoardList = HubQueries.GetAllPublicBoards();
            model.Message = message;

            foreach(BoardModel board in model.BoardList)
            {
                if (board.Password != null)
                {
                    board.IsPasswordProtected = true;
                }
            }

            return View(model);
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