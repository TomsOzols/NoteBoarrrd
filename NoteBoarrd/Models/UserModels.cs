using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteBoarrd.Models
{
    public class UserPageViewModel
    {
        public ICollection<BoardModel> VisitedBoards { get; set; }
        public ICollection<BoardModel> MyBoards { get; set; }
    }

    public class Culture
    {
        public int Id { get; set; }
        public string CultureTag { get; set; }
    }

    public class PreferencesModel
    {
        public List<Culture> cultures;

        public PreferencesModel()
        {
            cultures = new List<Culture>();
            cultures.Add(new Models.Culture
            {
                Id = 1,
                CultureTag = "lv-LV"
            });
            cultures.Add(new Culture
            {
                Id = 2,
                CultureTag = "en-US"
            });
        }

        public int CultureIdentifier { get; set; }
        public IEnumerable<SelectListItem> Culture
        {
            get
            {
                return new SelectList(cultures, "Id", "CultureTag");
            }
        }
    }

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