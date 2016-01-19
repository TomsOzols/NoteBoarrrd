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
                var query = db.Boards.Include("Notes").Where(x => x.Id == id);      //A rather bad fix, this should've gone into js as an ajax get request. (AND IT HAS - REMOVE THIS)
                currentBoard = query.FirstOrDefault();

            }

            return currentBoard;
        }
        
        public static ICollection<NoteModel> GetBoardNotes(int id)
        {
            ICollection<NoteModel> notes = null;
            using (var db = new ApplicationDbContext())
            {
                var query = db.Notes.Where(x => x.BoardId == id);
                notes = query.ToList();
            }

            return notes;
        }

        public static void UpdateBoardVisit(int id, string userName)
        {
            ApplicationUser user = AccountQueries.GetCurrentUser(userName);
            //UserBoards entryUpdate = new UserBoards()
            //{
            //    BoardId = id,
            //    UserId = user.Id,
            //    LastVisited = DateTime.Now
            //};
            using (var db = new ApplicationDbContext())
            {
                var entry = db.UserBoards.Where(x => x.BoardId == id && x.UserId == user.Id).SingleOrDefault();
                if (entry != null)
                {
                    entry.LastVisited = DateTime.Now;
                    db.Entry(entry).Property(e => e.LastVisited).IsModified = true;
                    //db.UserBoards.Attach(entryUpdate);
                    //var current = db.Entry(entryUpdate);
                    //current.Property(e => e.LastVisited).IsModified = true;
                }
                else
                {
                    UserBoards entryUpdate = new UserBoards()
                    {
                        BoardId = id,
                        UserId = user.Id,
                        LastVisited = DateTime.Now
                    };
                    db.UserBoards.Add(entryUpdate);
                }

                db.SaveChanges();
            }
        }
    }
}
