namespace WebApplication1.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public List<Book> Books { get; set; }

        public Ticket Ticket { get; set; }
    }
}
