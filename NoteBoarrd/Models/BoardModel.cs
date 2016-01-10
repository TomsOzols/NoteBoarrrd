using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteBoarrd.Models
{
    public class BoardModel : BoardListElement
    {
        public ICollection<NoteModel> Notes { get; set; }

        public string Password { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastChanged { get; set; }   //!!Make this a list of all changes made, and then whenever needed, check the latest change?

        public BoardRights Rights { get; set; }
    }


    public class BoardListElement
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsPasswordProtected { get; set; }
    }


    public class BoardRights
    {
        public int Id { get; set; }

        public bool Private { get; set; }
    }

    //public class BoardBlackList
    //{
    //    public BoardModel BoardId { get; set; }
    //}
}