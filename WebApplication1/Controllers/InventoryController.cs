using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services.IControllerServices;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryServices _inventoryServices;

        public InventoryController(IInventoryServices inventoryServices)
        {
            _inventoryServices = inventoryServices;
        }


        [HttpPost]
        public async Task<ActionResult<List<Inventory>>?> CreateTicket(InventoryDto request)
        {
            var result = await _inventoryServices.CreateTicket(request);

            if (result == null)
            {

                return NotFound("Doesnt exist");
            }

            return Ok(result);
        }

        
    }
}
