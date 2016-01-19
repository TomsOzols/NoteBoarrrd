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
                var query = db.Boards.Include("Notes").Where(x => x.Id == id);      //A rather bad fix, this should've gone into js as an ajax get request.
                currentBoard = query.FirstOrDefault();

            }

            return currentBoard;
        }
       
    }
}
