using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteBoarrd.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy_Id { get; set; }

        public int NoteId { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }

        public virtual NoteModel Note { get; set; }
    }
}