namespace WebApplication1.DTOs
{
    public record struct InventoryDto (string Username ,List<BookDto> Books, TicketDto Ticket);
}
