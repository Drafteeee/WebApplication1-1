using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Field { get; set; }

        [JsonIgnore]
        public List<Book> Books { get;}

    }
}
