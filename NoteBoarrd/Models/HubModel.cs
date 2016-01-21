using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteBoarrd.Models
{
    public class HubModel
    {
        public IEnumerable<BoardModel> BoardList { get; set; }
        public string Message { get; set; }
    }
}