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

        public string Owner { get; set; }

        public DateTime Created { get; set; }
    }
}