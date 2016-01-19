using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteBoarrd.Models
{
    public class UserModel
    {
        public UserBoards Boards { get; set; }          //!!Check this later - it might need to be a boardmodel collection or such
    }

    public class UserBoards
    {
        public int Id { get; set; }
        public DateTime LastVisited { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int BoardId { get; set; }
        public virtual BoardModel Board { get; set; }
    }
}