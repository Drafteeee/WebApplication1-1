using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public int date { get; set; }

        [JsonIgnore]
        public List<Feedback> Feedbacks { get; set;}

    }
}
