using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<Book>? Books { get; set; }
    }
}
