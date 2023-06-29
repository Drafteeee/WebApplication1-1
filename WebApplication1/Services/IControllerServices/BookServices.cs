using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;

namespace WebApplication1.Services.IControllerServices
{
    public class BookServices : IBookService
    {

        
        private readonly DataContext _context;

        public BookServices(DataContext context) {
            _context = context;
        }




        public async Task<List<Book>> AddBooks(BookDto request)
        {
            var book = new Book{ 
            
               name = request.Name,
            
            };

            var author = request.Authors.Select(a => new Author { Name = a.Name, Books = new List<Book> { book } }).ToList();
            var ganre = request.Ganres.Select(a => new Ganre { Name = a.Name, Books = new List<Book> { book } }).ToList();

            book.author = author;
            book.ganres= ganre;


            _context.books.Add(book);
            await _context.SaveChangesAsync();
            return await _context.books.Include(b => b.author).Include(b=> b.ganres).ToListAsync();
        }

        public async Task<List<Book>?> DelBooks(int id)
        {
            var book = await _context.books.FindAsync(id);
            if (book == null)
            {

                return null;
            }

            _context.books.Remove(book);
            await _context.SaveChangesAsync();

            return await _context.books.ToListAsync();

        }

        public async Task<List<Book>> GetAllBooks()
        {
            
            var books = await _context.books.Include(b=> b.author).Include(b=>b.ganres).ToListAsync();
            return books;
        }

        public async Task<Book?> GetOneBooks(int id)
        {

            var book = await _context.books.Include(b => b.author).Include(b => b.ganres).FirstOrDefaultAsync(b =>b.Id == id);
            if (book == null)
            {

                return null;
            }
            return book;
        }

        
        
    }
}
