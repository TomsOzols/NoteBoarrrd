using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoteBoarrd.Models;
using NoteBoarrd.Queries;
using System.Data.Entity;
using System.Collections.ObjectModel;

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
                        IsPasswordProtected = q.Password != null ? true : false
                    });
                publicBoards = query.ToList().Select(x => new BoardModel { Id = x.Id, Name = x.Name, IsPasswordProtected = x.IsPasswordProtected });
            }

            return publicBoards;
        }

        public static int? AddBoard(BoardModel board, string userName)
        {
            board.CreatedBy = AccountQueries.GetCurrentUser(userName);
            //board.CreatedBy_Id = board.CreatedBy.Id;
            board.Notes = new Collection<NoteModel>();
            board.UserBoards = new Collection<UserBoards>();
            int newBoardIdentifier;
            using (var db = new ApplicationDbContext())
            {
                //try
                //{
                db.Entry(board.CreatedBy).State = EntityState.Unchanged;
                    db.Boards.Add(board);
                    db.SaveChanges();
                    newBoardIdentifier = board.Id;
                //}
                //catch
                //{
                //    return null;                //!!Wow, this catch actually works
                //}
            }

            return newBoardIdentifier;
        }
    }
}