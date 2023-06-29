namespace WebApplication1.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public int Time { get; set; }
        
    }
}
