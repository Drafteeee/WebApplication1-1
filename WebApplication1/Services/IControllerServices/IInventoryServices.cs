using WebApplication1.DTOs;

namespace WebApplication1.Services.IControllerServices
{
    public interface IInventoryServices
    {
        Task<List<Inventory>?> CreateTicket(InventoryDto request);
        //Task<List<Inventory>?> AddToInventory(int i, int a);

    }
}
