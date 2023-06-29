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

        public async Task<List<Inventory>?> AddToInventory(int i,int a, InventoryDto request)
        {
            var inventory = await _context.inventory.FirstOrDefaultAsync(c => c.Id == i);

            if (inventory == null)
            {
                return null;

            }
            var book = _context.books.FirstOrDefault(c => c.Id == a);
            if (book == null)
            {
                return null;
            }

            var mbook = request.Books.Select(b => )

            inventory.Books = 

            _context.inventory.Add(inventory);
            await _context.SaveChangesAsync();

            return await _context.inventory.ToListAsync();
        }

    }
}
