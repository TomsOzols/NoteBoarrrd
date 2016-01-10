using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteBoarrd.Models;

namespace NoteBoarrd.Queries
{
    public static class BoardQueries
    {
        public static BoardModel GetBoardInfo(int id)
        {
            BoardModel currentBoard = null;
            using (var db = new ApplicationDbContext())
            {
                currentBoard = db.Boards.Where(x => x.Id == id).FirstOrDefault();
            }

            return currentBoard;
        }
       
    }
}
