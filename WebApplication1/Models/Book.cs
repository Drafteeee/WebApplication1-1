using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int date { get; set; }

       
        public List<Feedback> feedbacks { get; set;}

    }
}
