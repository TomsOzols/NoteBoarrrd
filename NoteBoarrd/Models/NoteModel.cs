using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoarrd.Models
{
    /// <summary>
    /// Not sure if i'll even use this enum.
    /// </summary>
    public enum NoteType
    {
        Text,
        Image,
        ImageText
    }

    public class NoteModel
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public ICollection<CommentModel> Comments { get; set; }

        public float XCoord { get; set; }

        public float YCoord { get; set; }

        public int BoardId { get; set; }

        public BoardModel Board { get; set; }
    }
}
