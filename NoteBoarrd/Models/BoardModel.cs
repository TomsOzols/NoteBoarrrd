using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Resources.Res;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBoarrd.Models
{
    //public class BoardListViewModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public bool IsPasswordProtected { get; set; }
    //}

    /// <summary>
    /// Using this interface as reference for the model binder to fight against overposting/mass assignment.
    /// </summary>
    public class AddBoardModel
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public bool IsPrivate { get; set; }
    }

    public class BoardModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "BoardNameRequired", ErrorMessageResourceType = typeof(WebResources))]
        [StringLength(100, ErrorMessageResourceName = "BoardLengthTooLow", ErrorMessageResourceType = typeof(WebResources), MinimumLength = 3)]
        [Display(Name = "BoardName", ResourceType = typeof(WebResources))]
        public string Name { get; set; }

        [NotMapped]
        public bool IsPasswordProtected { get; set; }

        public virtual ICollection<NoteModel> Notes { get; set; }

        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessageResourceName = "PasswordLengthTooLow", ErrorMessageResourceType = typeof(WebResources), MinimumLength = 3)]
        [Display(Name = "Password", ResourceType = typeof(WebResources))]
        public string Password { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastChanged { get; set; }   //!!Make this a list of all changes made, and then whenever needed, check the latest change?

        public virtual ICollection<UserBoards> UserBoards { get; set; }

        [Display(Name = "IsBoardPrivate", ResourceType = typeof(WebResources))]
        public bool IsPrivate { get; set; }

        public string CreatedBy_Id { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }

        [NotMapped]
        public NoteModel NewNote { get; set; }
    }

    //public class BoardBlackList
    //{
    //    public BoardModel BoardId { get; set; }
    //}
}