using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services.IControllerServices
{
    public class BookServices : IBookService
    {

        
        private readonly DataContext _context;

        public BookServices(DataContext context) {
            _context = context;
        }




        public async Task<List<Book>> AddBooks(Book book)
        {

            _context.books.Add(book);
            await _context.SaveChangesAsync();
            return await _context.books.ToListAsync();
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
            var books = await _context.books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetOneBooks(int id)
        {

            var book =await _context.books.FindAsync(id);
            if (book == null)
            {

                return null;
            }
            return book;
        }

        
        
    }
}
