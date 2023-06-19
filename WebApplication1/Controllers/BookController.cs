using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.IControllerServices;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }



        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
           return await _bookService.GetAllBooks();

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetOneBooks(int id)
        {
            var result = await _bookService.GetOneBooks(id);
            if (result == null)
            {

                return NotFound("Doesnt exist");
            }


            return Ok(result);

        }



        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBooks(Book book)
        {
            var result = await _bookService.AddBooks(book);

            return Ok(result);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DelBooks(int id)
        {
            var result = await _bookService.DelBooks(id);
            if (result == null)
            {

                return NotFound("Doesnt exist");
            }


            return Ok(result);

        }

    }
}
