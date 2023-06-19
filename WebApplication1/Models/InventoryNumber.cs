namespace WebApplication1.Models
{
    public class InventoryNumber
    {
        public int Id { get; set; }
        public DateTime Date_issue { get; set; }
        public int Return { get; set; }

        public Reader reader { get; set; }
    }
}
