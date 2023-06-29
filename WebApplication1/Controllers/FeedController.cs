using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services.IControllerServices;

namespace WebApplication1.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {

        private readonly IFeedServices _feedServices;

        public FeedController(IFeedServices feedServices)
        {
            _feedServices = feedServices;
        }

        

        [HttpPost("{id}")]
        public async Task<ActionResult<List<Feedback>>?> AddFeedBack(BookDto request, int id)
        {
            var result = await _feedServices.AddFeedBack(request, id);

            if (result == null)
            {

                return NotFound("Doesnt exist");
            }

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Book>?> GetFeedBack( int id)
        {
            var result = await _feedServices.GetFeedBack(id);

            if (result == null)
            {

                return NotFound("Doesnt exist");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Feedback>>?> DeleteFeedBack(int id)
        {
            var result = await _feedServices.DeleteFeedBack(id);
            if (result == null)
            {

                return NotFound("Doesnt exist");
            }

            

            return Ok(result);
        }

    }
}
