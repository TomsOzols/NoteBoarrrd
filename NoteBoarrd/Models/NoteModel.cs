using Newtonsoft.Json;
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

    /// <summary>
    /// X and Y mark the top-left corner of the figure.
    /// </summary>
    public class NoteModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonIgnore]
        public ICollection<CommentModel> Comments { get; set; }

        [JsonProperty("left")]
        public float left { get; set; }

        [JsonProperty("top")]
        public float top { get; set; }

        [JsonProperty("boardId")]
        public int BoardId { get; set; }

        [JsonIgnore]
        public BoardModel Board { get; set; }
    }
}
