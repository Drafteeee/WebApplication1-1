using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.DTOs;

namespace WebApplication1.Services.IControllerServices
{
    public class InventoryServices : IInventoryServices
    {

        private readonly DataContext _context;

        public InventoryServices(DataContext context)
        {
            _context = context;
        }


        public async Task<List<Inventory>?> CreateTicket(InventoryDto request)
        {
            var inventory = new Inventory
            {
                Name = request.Username,
            };

            var ticket = new Ticket {Time = request.Ticket.Time };

            inventory.Ticket = ticket;

            _context.inventory.Add(inventory);
            await _context.SaveChangesAsync();

            return await _context.inventory.ToListAsync();
        }

        //

    }
}
