using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoteBoarrd.Models;

namespace NoteBoarrd.Queries
{
    public static class HubQueries
    {
        public static ICollection<BoardListElement> GetAllPublicBoards()
        {
            ICollection<BoardListElement> publicBoards;
            using (var db = new ApplicationDbContext())
            {
                var query = db.Boards
                    .Where(x => x.Rights.Private == false)
                    .Select(q => new BoardListElement{ Id = q.Id, Name = q.Name, IsPasswordProtected = q.IsPasswordProtected});
                publicBoards = query.ToList();
            }

            return publicBoards;
        }

        public static int AddBoard(BoardModel board)
        {
            int newBoardIdentifier;
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    db.Boards.Add(board);
                    db.SaveChanges();
                    newBoardIdentifier = board.Id;
                }
                catch
                {
                    return -1;              //!!Yay, lazy magic numbers
                }
            }

            return newBoardIdentifier;
        }
    }
}