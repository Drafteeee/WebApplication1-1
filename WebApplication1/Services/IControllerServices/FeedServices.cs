using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;

namespace WebApplication1.Services.IControllerServices
{
    public class FeedServices: IFeedServices
    {
        private readonly DataContext _context;

        public FeedServices(DataContext context)
        {
            _context = context;
        }


        public async Task<List<Feedback>?> AddFeedBack(BookDto request, int id)
        {
            var book = await _context.books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            var feedback = request.Feedback.Select(f => new Feedback { Username = f.Username, Field = f.Description, Book = book }).ToList();

            book.feedbacks = feedback;

            _context.feedbacks.AddRange(feedback);
            await _context.SaveChangesAsync();

            return await _context.feedbacks.ToListAsync();
        }

        public async Task<Book?> GetFeedBack(int id)
        {
            var book = await _context.books.Include(b => b.feedbacks).FirstOrDefaultAsync(b => b.Id == id);



            return book;
        }

        public async Task<List<Feedback>?> DeleteFeedBack(int id)
        {
            var feedback = await _context.feedbacks.FindAsync(id);
            if (feedback == null)
            {

                return null;
            }

            _context.feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return await _context.feedbacks.ToListAsync();
        }

    }
}
