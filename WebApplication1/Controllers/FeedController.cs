using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.IControllerServices;

namespace WebApplication1.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IFeed _feed;

        public FeedController(IFeed feed)
        {
            _feed = feed;
        }


        [HttpPost]
        public async Task<ActionResult<List<Feedback>>> AddFeed(Feedback feed)
        {
            var result = await _feed.AddFeed(feed);

            return Ok(result);
        }


    }
}
