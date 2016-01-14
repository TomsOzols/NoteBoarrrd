using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoteBoarrd.Models;

namespace NoteBoarrd.Queries
{
    public static class HubQueries
    {
        public static IEnumerable<BoardModel> GetAllPublicBoards()
        {
            IEnumerable<BoardModel> publicBoards;
            using (var db = new ApplicationDbContext())
            {
                var query = db.Boards
                    .Where(x => x.IsPrivate == false)
                    .Select(q => new
                    {
                        Id = q.Id,
                        Name = q.Name,
                        IsPasswordProtected = q.IsPasswordProtected
                    });                       //!! This is all breaking apart
                publicBoards = query.ToList().Select(x => new BoardModel { Id = x.Id, Name = x.Name, IsPasswordProtected = x.IsPasswordProtected });
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