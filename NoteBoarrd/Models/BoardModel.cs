using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteBoarrd.Models
{
    public class BoardListModel
    {
        public BoardModel NewBoardModel { get; set; }
        public IEnumerable<BoardModel> BoardList { get; set; }
    }

    public class BoardModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPasswordProtected { get; set; }   //!!Find some Entity framework ignore attribute, and then on view just fill this if Password is present

        public ICollection<NoteModel> Notes { get; set; }

        public string Password { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastChanged { get; set; }   //!!Make this a list of all changes made, and then whenever needed, check the latest change?

        public virtual ICollection<UserBoards> UserBoards { get; set; }

        public bool IsPrivate { get; set; }


    }

    //public class BoardBlackList
    //{
    //    public BoardModel BoardId { get; set; }
    //}
}