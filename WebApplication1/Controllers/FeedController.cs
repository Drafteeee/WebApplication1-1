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
        private readonly DataContext _context;

        public FeedController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<List<Book>>> AddFeedBack(BookDto request, int id)
        {
            var book = await _context.books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound("Doesnt exist");
            }

            var feedback = request.Feedback.Select(f => new Feedback {Username = f.Username, Field = f.Description, Book = book}).ToList();

            book.feedbacks = feedback;

            _context.feedbacks.AddRange(feedback);
            await _context.SaveChangesAsync();

            return Ok(feedback);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Book>>> GetFeedBack( int id)
        {
            var book = await _context.books.Include(b => b.feedbacks).FirstOrDefaultAsync(b => b.Id == id);

            

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Feedback>>> DeleteFeedBack(int id)
        {
            var feedback = await _context.feedbacks.FindAsync(id);
            if (feedback == null)
            {

                return NotFound("Doesnt exist");
            }

            _context.feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return Ok(feedback);
        }

    }
}
